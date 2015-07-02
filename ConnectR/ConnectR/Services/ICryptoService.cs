// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConnectR.Services
{
    public interface ICryptoService
    {
        void CreateHash(byte[] data, out byte[] hash, out byte[] salt);

        byte[] ComputeHash(byte[] data, byte[] salt);
    }
}