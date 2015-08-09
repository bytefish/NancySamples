// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ConnectR.Infrastructure.Authentication;
using ConnectR.Infrastructure.Database;
using ConnectR.Infrastructure.Database.Entities;
using ConnectR.Model;
using ConnectR.Requests;
using Nancy.Security;
using NPoco;
using System.Collections.Generic;
using System.Linq;

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
                // Let's do this in a transaction, so we cannot register two users
                // with the same name. Seems to be a useful requirement.
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

        public bool TryAuthentifcate(Credentials credentials, out Model.UserIdentity identity)
        {
            identity = null;

            using (var database = DatabaseFactory.GetDatabase())
            {
                User user = database.Query<User>().FirstOrDefault(x => x.Name == credentials.UserName);

                // Check if there is a User:
                if (user == null)
                {
                    return false;
                }

                // Make sure the Hashed Passwords match:
                if (user.PasswordHash != cryptoService.ComputeHash(credentials.Password, user.PasswordSalt))
                {
                    return false;
                }

                // We got a User, now obtain his claims from DB:
                IList<Claim> claims = database.Fetch<Claim>(@"
                                select c.*
                                from auth.user u 
                                    inner join auth.user_claim uc on u.user_id = uc.user_id
                                    inner join auth.claim c on uc.claim_id = c.claim_id
                                where u.user_id = @0", user.Id);
                
                // And return the UserIdentity:
                identity = Convert(user, claims);
                
                return true;
            }
        }

        /// <summary>
        /// Converts between Model and DB Entity.
        /// </summary>
        UserIdentity Convert(User user, IList<Claim> claims)
        {
            if (user == null)
            {
                return null;
            }
            return new UserIdentity()
            {
                Id = user.Id,
                Name = user.Name,
                Claims = Convert(claims)
            };
        }

        /// <summary>
        /// Converts between Model and DB Entity.
        /// </summary>
        ClaimIdentity Convert(Claim entity)
        {
            return new ClaimIdentity()
            {
                Id = entity.Id,
                Type = entity.Type,
                Value = entity.Value
            };
        }

        /// <summary>
        /// Converts between Model and DB Entity.
        /// </summary>
        IList<ClaimIdentity> Convert(IList<Claim> entities)
        {
            if (entities == null)
            {
                return null;
            }
            return entities.Select(x => Convert(x)).ToList();
        }
    }
}