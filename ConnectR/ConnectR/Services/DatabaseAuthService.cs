// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Infrastructure.Database;
using ConnectR.Infrastructure.Database.Entities;
using ConnectR.Requests;
using Nancy.Security;
using NPoco;
using System.Collections.Generic;

namespace ConnectR.Services
{
    /// <summary>
    /// Simple Database-based Authentification Service. 
    /// </summary>
    public class DatabaseAuthService : BaseService, IAuthService
    {
        private ICryptoService cryptoService;

        public DatabaseAuthService(IDatabaseFactory databaseFactory, ICryptoService cryptoService) 
            : base(databaseFactory)
        {
            this.cryptoService = cryptoService;
        }

        public void Register(RegisterUserRequest register)
        {
            using (var database = DatabaseFactory.GetDatabase())
            {
                using (var tran = database.GetTransaction())
                {
                    string hashBase64;
                    string saltBase64;

                    cryptoService.CreateHash(register.Password, out hashBase64, out saltBase64);

                    User user = new User()
                    {
                        Name = register.UserName,
                        PasswordHash = hashBase64,
                        PasswordSalt = saltBase64
                    };

                    database.Insert(user);

                    tran.Complete();
                }
            }
        }

        public bool TryAuthentifcate(AuthenticateUserRequest request, out IUserIdentity identity)
        {
            using (var database = DatabaseFactory.GetDatabase())
            {
                identity = null;

                User user = database.Query<User>().FirstOrDefault(x => x.Name == request.UserName);

                if (user == null)
                {
                    return false;
                }

                if (user.PasswordHash != cryptoService.ComputeHash(request.Password, user.PasswordSalt))
                {
                    return false;
                }

                IList<string> claims = database.Fetch<string>(@"
                                select c.*
                                from auth.user u 
                                    inner join auth.user_claim uc on u.user_id = uc.user_id
                                    inner join auth.claim c on uc.claim_id = c.claim_id
                                where u.user_id = @0", user.Id);

                //identity = new DefaultUserIdentity(user.Name, claims);

                return true;
            }
        }
    }
}