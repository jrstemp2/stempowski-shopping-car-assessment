# stempowski-shopping-car-assessment

## General Information and thoughts
- This is a console application. I kept it simple to show some object oriented programming. 
- You will see some models and a basic class I am using as a controller. The controller will house methods to validate console inputs as well as building the merchandise item object and generating the receipt with calculated fields. 
- I also added a testing solution to test some, but not all of the code. I wanted to shopw you that I can use xUnit testing to do Fact and Theory testing. 
- If I had more time, I would have fleshed this out into an Angular project with a fully functional frontend that would validate inputs there. The .NET portion would have been structured more as an API to handle all the calculations and heavy lifting. 
- If i had more time, I would also have taken the test coverage up to 100% as that is the standard of my current employer and a good rule of thumb. 
- It's been a long time since I made a console application and I forgot how many while loops I would need to make this work as desired. I added a lot of validation to really control the quality of what is typed in the consiole b the end user. 

### Running the app from your terminal
- If you do not want to run the app from Visual studio, you can open a terminal run it that way.
- Navigate to the StempowskiShoppingCart directory in your terminal and type dotnet run. This should start the application.

### Sales Tax
- I have used a Math.Ceiling to force UP to the nerest 5 cents. If Tax is 1.7015 it will round up to 1.75. This is how I understood the instructions.
- If the item being bought is not tax free and it is imported, Sales tax will be 10% plus 5% import tax.

## How to run this application:
- Copy the code url via the green code button on the repository page (If you want, you can FORK this repository)
- Create a new folder on you Desktop and open a GitBash terminal. 
- In your terminal, type git clone {PASTE THE LINK HERE}
- Once cloned, open this in Visual Studio and Right Click on the solution and select Restore NuGet Packages
- Click the Run Button and have some fun!

## Unit Testing
- I did not cover everything, but wanted to show you that I do write my own unit tests.
- You will see a combination of FACT and THEORY tests.
- Please run the testing suite in Visual Studio to see that they all pass.