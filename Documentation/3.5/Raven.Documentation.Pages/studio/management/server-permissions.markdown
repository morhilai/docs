# Manage Your Server: Server Permissions

As described in [Configuration : Authentication & Authorization](../../server/configuration/authentication-and-authorization), you can use two different authentication methods in RavenDB.   
In both methods, each user is associated with a permission type:   
- `Admin`   
- `Read, Write`   
- `Read Only`   

The permission type is set by an admin when creating user settings in [Windows Authentication](./windows-authentication) or when using [API keys](./api-keys).

### Permissions to system database

Permissions to the system database describe which management sections a user can access.
The following table shows the sections of the studio management and their associated permissions:

| Studio management section| Write | Read |
|:-------------------------|:------|:-----|
| API keys                 | write | read |
| windows authentication   | write | read |
| cluster                  | admin | read |
| global configuration     | write | read |
| server smuggling         | admin | n/a  |
| backup                   | admin | n/a  |
| compact                  | admin | n/a  |
| restore                  | admin | n/a  |
| admin logs               | admin | n/a  |
| server topology          | admin | n/a  |
| traffic watch            | admin | n/a  |
| license information      | admin | read |
| gather debug information | admin | n/a  |
| IO test                  | admin | n/a  |
| disk IO viewer           | admin | read |
| administrator js console | admin | n/a  |
| studio configuration     | write | read |
| hot spare                | admin | n/a  |
