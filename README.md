# Azure Functions Test Strategies
I love Azure Functions. I use them all the time to execute small pieces of code without having to worry about how they run.

Testing all code is recommended, however you may get the best results by wrapping up a Function's logic and creating tests outside the Function.

Writing unit tests for Azure Functions is just like writing unit tests for any other piece of code. There is some logic, that has input and output parameters, and you need to simulate those.

## Features
The following functions are demonstration here.

* [HttpTrigger](./Functions/Functions/HttpTrigger.cs)
* [QueueTrigger](./Functions/Functions/QueueTrigger.cs)
* [TimerTrigger](./Functions/Functions/TimerTrigger.cs)
* [DurableFunction](./Functions/Functions/DurableFunction.cs)

## Prerequisites
    Visual Studio 2019 .Net Core Runtime
