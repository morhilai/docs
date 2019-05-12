# Getting started: Playground Server

Live-test server offers a full functionality of a RavenDB server and is available at [live-test.ravendb.net](http://live-test.ravendb.net/). We encourage you to check it out and test various functionalities.

{INFO:Information}

- server accepts remote connectivity, so you can build your applications locally for testing purposes and specify its address - `http://live-test.ravendb.net/` (more [here](../client-api/creating-document-store))
- sample database can be deployed as in any normal instance (more [here](../studio/overview/tasks/create-sample-data))

{INFO/}

{WARNING:Important}

- all databases available at `live-test.ravendb.net` server are publicly available and can be accessed, managed and copied by any user.
- periodicaly all databases will be removed

{WARNING/}

## LINQPad

Driver for [LINQPad](https://www.linqpad.net/) that supports RavenDB connectivity was created by Ronnie Overby. It can be downloaded from project [GitHub page](https://github.com/ronnieoverby/RavenDB-Linqpad-Driver) (compiling the solution will overwrite the installed driver) or installed directly through LINQPad.

### Installation

Step 1. Click on `Add Connection` in LINQPad.

![Figure 1. Getting started. Playground Server. LINQPad. Installation. Step 1.](images/linqpad-1.png)  

Step 2. In `Choose Data Context` view click on `View more drivers...`.

![Figure 2. Getting started. Playground Server. LINQPad. Installation. Step 2.](images/linqpad-2.png)  

Step 3. In `Choose a Driver` view find a RavenDB driver on a list of drivers and install it or if you are interested in manual installation, click on `Browse` at the bottom of the page and specify `.lpx` file with the driver.

![Figure 3. Getting started. Playground Server. LINQPad. Installation. Step 3.](images/linqpad-3.png)  

### Connecting

Step 1. Select `RavenDB Driver` from `Choose Data Context` view.

![Figure 4. Getting started. Playground Server. LINQPad. Connecting. Step 1.](images/linqpad-4.png)  

Step 2. `RavenDB Connection` view will appear where you can specify all needed information and credentials that will allow you to connect to a database (e.g. you can specify `http://live-test.ravendb.net/`)

![Figure 5. Getting started. Playground Server. LINQPad. Connecting. Step 2.](images/linqpad-5.png)  

### Querying

Please visting project [GitHub page](https://github.com/ronnieoverby/RavenDB-Linqpad-Driver) for more information on how to query or watch [this](https://www.youtube.com/watch?v=XgsPvyk0bjM) video created by author of the driver that will guide you through available functionalities.

## Related articles

- [Getting started](../start/getting-started)
