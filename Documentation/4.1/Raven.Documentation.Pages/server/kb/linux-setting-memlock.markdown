Linux: Setting `memlock` when using encrypted database
---
Encrypted database uses extensively sodium library which requires high values of locked memory limits.
`memlock` refers to memory that will not be paged out, and it's limit can be viewed usign `ulimit -l`.
The modification of `memlock` limit settings can be achieved by in running session with `prlimit`:

Example, for 1MB limit:
```
prlimit -p pid --memlock 1MB:1MB
```

Persistant settings can be achieved by adding to `/etc/security/limits.conf` the following:
```
* soft     memlock         1000
* hard     memlock         1000
```

