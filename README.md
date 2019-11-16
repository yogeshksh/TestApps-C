Info:

I have created a  solution that contains a standard Asp.Net Core project with an Angular cli project.
 Using Visual Studio F5 will build both the server side and client side code and launch the website.

Once running the client side code (found in TestApp/src) 

- I have created sample unit tests but not working correctly due to memory cache, as mocking memory cache is not easy , I have tried but that will require more effort so
 i have left to just show how this can be done

- Similarly, for the Memorycache for expiring parameters, i have defined in the config file and need to be read from there and injected into controller but for time being i have just used hard coded values

