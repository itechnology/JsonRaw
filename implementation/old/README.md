####This is just an old implemetation put here as proof of concept
It works perfectly fine, but does not support recursion like the posted spec proposes.

If you build a client or server side implementation that supports the JsonR Spec, please submit it to the project

1. Clone the project
2. Add you implementation
3. Issue a pull request


..more to come soon



####Usage:

1. Add jsonr.js to your HTML page
2. Configure your project so that the string result from GetUsers() is returned to your browser client

Which should return:

    {"Values":[["Robert",41],["Teddy",35]],"Keys":["Pseudo","Age"]}


Then call merge() while passing it your result.

Now you should have:

    [{"Age":31,"Pseudo":"Robert"},{"Age":45,"Pseudo":"Bob"}]


####Note:
In this implementation size savings only start to kick in when you are dealing with collection containing more than 2 items