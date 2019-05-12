# Client API: What is a public API?

In RavenDB we are doing our best to not introduce any breaking changes in the public API between minor versions of our client API. This means that the upgrade between version 4.0.A and 4.0.B or even 4.C.D should be smooth.

## What is considered a public API?

Very common question that we are getting is what we consider a public API. The answer to this question is not straightforward, because our .NET Client contains two DLLs

- `Raven.Client.dll`
- `Sparrow.dll`

And a lot of types in those DLLs are shared between Client, Tools and Server so naturally some changes between versions might occur. But does this mean that we are changing the public API? In our opinion no, because there is a set of interfaces/methods/types that we consider unchangeable.

Those interfaces/methods/types are related to the most common actions of the client that cover 99,9% of the usage cases. What are those you might ask? Those are related to the **session actions**, including **advanced session operations**, **operations for manipulating documents and attachments** and **related types**. So any changes here (excluding new features) should be considered a bug, but this also does not mean that the changes will not occur at all, they can, but those will be a backward-compatibile changes e.g. we might add an optional parameter to method X that will not brake current behavior but will extend the functionality.

## Binary-level compatibility

We guarantee binary-level compatibility **within minor versions** (e.g. 4.0.X and 4.0.Y) of our client library. **Between minor versions** there is no binary-level compatibility guarantees, but we guarantee source-level compatibility. What does it mean? It means that when you are upgrading from version 4.0.X to 4.0.Y you do not have to recompile your application - simple DLL swap should work. For 4.0.X to 4.5.Y updates we do not support that, so your application needs to be recompiled.

### NuGet dependency

Given no binary compatibility is guaranteed between minors, any NuGet package taking a dependency on Raven packages should be locked down to the patch range. For example:

```
<dependency id="RavenDB.Client" version="[4.0.0, 4.1.0)" />
```

As such that NuGet package will need to be re-compile and re-deployed (with a new dependency range) on every minor release of the RavenDB NuGet package.

## Related articles

- [.NET Client Versions](../client-api/net-client-versions)
- [Backward Compatibility](../client-api/faq/backward-compatibility)
