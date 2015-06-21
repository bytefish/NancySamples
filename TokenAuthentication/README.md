# TokenAuthentication #

[Nancy.Authentication.Token]: https://github.com/NancyFx/Nancy/wiki/Token-Authentication
[cURL]: http://curl.haxx.se
[NPoco]: https://github.com/schotime/NPoco
[log4net]: https://logging.apache.org/log4net/

This project shows how to implement basic TokenAuthentication with [Nancy.Authentication.Token]. It uses 
[NPoco] for the database access and [log4net] for the logging. This project does not implement any rate 
limiting, so you shouldn't use it in production.

The sample provides two modules ``AuthModule`` and ``FileUploadModule``.

## Database ##

To create the ``sampledb`` run:

```
PS C:\Users\philipp> psql -U postgres
psql (9.4.1)
postgres=# CREATE USER philipp WITH PASSWORD 'test_pwd';
CREATE ROLE
postgres=# CREATE DATABASE sampledb
postgres-#   WITH OWNER philipp;
CREATE DATABASE
```

And then you can create the database tables by running the ``Database/create_database.bat`` script in this repository.

## AuthModule ##

The module exposes the following endpoints:

* ``auth/register``
    * Registers a new API user.
* ``auth/token`` 
    * Generates a new Authorization token for a given API user

To register and obtain a Token a simple JSON object is used, stored to ``user_password.json``:

```
{
  "username" : "philipp",
  "password" : "test_pwd"
}
``` 

A sample request for registering with cURL, will be acknowledged with a HTTP Status Code ``200`` on success:

```
curl --verbose -H "Content-Type: application/json" --data @user_password.json http://localhost:12008/auth/register
```

We can now obtain a Token:

```
curl --verbose -H "Content-Type: application/json" --data @user_password.json http://localhost:12008/auth/token
```

And we will get the Authorization Token:

```
< HTTP/1.1 200 OK
< Cache-Control: private
< Content-Type: application/json; charset=utf-8
< Vary: Accept
* Server Microsoft-IIS/8.0 is not blacklisted
< Server: Microsoft-IIS/8.0
< Link: </token.xml>; rel="application/xml"
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?RDpcZ2l0aHViXE5hbmN5U2FtcGxlc1xUb2tlbkF1dGhlbnRpY2F0a
W9uXFRva2VuQXV0aGVudGljYXRpb25TYW1wbGVcYXV0aFx0b2tlbg==?=
< X-Powered-By: ASP.NET
< Date: Sat, 20 Jun 2015 12:56:18 GMT
< Content-Length: 113
<
{"token":"cGhpbGlwcA0KDQo2MzU3MDQwMTc3ODc0NDQ5MzYNCmN1cmwvNy4zNi4w:J5x7OW+LIMobZ
BYeiMkamX4sG41ACZJeTPhjtGqkqTs="}
```

### FileUploadModule ###

We can now use the token for the sample ``FileUploadModule``, which exposes the following endpoints:

* ``file/upload``
    * Endpoint for uploading a file. Requires an Authentication Token.

The file can be uploaded by sending a simple ``multipart/form-data`` with the fields:

* ``file``
    * The file content.
* ``title``
    * The title of the File.
* ``description``
    * A description of the files content.
* ``tags``
    * A comma separated list of tags.

You'll need to add the ``Authorization`` Header with the Token obtained from the ``AuthModule``.

A sample cURL request looks like this:

```
curl --verbose 
	--header "Authorization: Token cGhpbGlwcA0KDQo2MzU3MDQwMTc3ODc0NDQ5MzYNCmN1cmwvNy4zNi4w:J5x7OW+LIMobZBYeiMkamX4sG41ACZJeTPhjtGqkqTs=" 
	--form file=@"D:\images\an_image.png" 
	--form title="File Title"
	--form description="File Description"
	--form tags="Tag1,Tag2"
	http://localhost:12008/upload
```