# Client API: How to Store Dates in RavenDB Using UTC and Using Local Time

When you store a date to RavenDB, it will save whether it's UTC or not.  When it's not UTC, a local date is treated as "Unspecified".
  
However, if you have people from around the world using the same database and you use unspecified local times, the offset is not stored. If you want to deal with this scenario you need to store the date using a `DateTimeOffset` that will store the date and time, and its time zone offset.

The decision of whether to use UTC, Local Time, or `DateTimeOffset` is an application decision, not an infrastructure decision.  There are valid reasons for using any one of these.


##ISO 8601 Compliance and Default Storing Formats

RavenDB is [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) compliant.   

The default storing format for `DateTime` is :  **"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffff"**

For storing `DateTimeOffset`, RavenDB uses the [Round-trip ("o")](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#Roundtrip) format

##More Information
For detailed information about this topic, please refer to the [Working with Date and Time in RavenDB](https://codeofmatt.com/date-and-time-in-ravendb/) article written by Matt Johnson.
