## COM741 Web Applications Development

### Practical 5 (Introduction to MVC)

In this practical we are introduced to multi-page web application development (using the ***model view controller (MVC)*** design pattern). The main point to note is that each time we navigate to a page via a url in the browser, a request is sent to the server. The server determines the controller/action to handle the request based on the url. The controller action then generates any data needed for the page and then renders a new html page on the server, which is then sent back to the browser. The technology used on the server to allow us to interpolate html and C# code is called ```Razor```. These razor files are contained in the project ```Views``` folder and end with a ```.cshtml``` file extension. 


***Note:*** If you would like to complete this practical locally using VSCode, rather than in Replit, and still be able to submit your solutions via replit, then take a look at the optional Q7.


1. Create a new MVC project by opening the Command/Shell window and typing the command below. If you make a mistake then simply delete any folder created and re-execute the command. We are creating an MVC project template.

    - ```$ dotnet new mvc -o SMS.Web```

    - **IMPORTANT:** For the purposes of this practical we will be making some changes to the default project configuration

        - Edit ```Properties/launchsettings.json``` and edit all occurances of the ```applicationUrl``` property in ```"http"``` and ```"https"``` profiles, from ```localhost``` to  ```0.0.0.0```. Note this is normally ***not*** required when only running a project on your own computer.

        - Edit ```Program.cs``` and comment out the command ```//app.UseHttpsRedirection();```. This is to stop the server trying to automatically redirect all traffic to https.

        - Disable the use of the default Layout by editing the  ```Views/Shared/_ViewStart.cshtml``` file and comment out the Layout configuration as shown below. We will learn more about layouts in the next practical.
    
            ```
            @{
                // Layout = "_Layout";
            }
            ```
    
        - To ensure the project is configured correctly - execute the project using the following command in the Command/Shell ```$ dotnet run --project SMS.Web```. If using replit, the project should start and open in a mini-browser window within the repl. To open a browser in a new tab, click the arrow icon in the top right hand corner of the mini-browser window. If using VSCode on a local computer then simply open a browser window and enter the url ```http://localhost:5000``` to view the application. 

        - To stop the project press ```Ctrl-C``` in the Command/Shell.

        - To configure the Replit run button to start the project, ensure hidden files are visible in your repl, then edit the .replit file and change the run command to ```run="dotnet run --project SMS.Web"``` 
 
        - **NOTE:** When using replit for development, each time you modify the solution you have to stop and restart the server as outlined above, then refresh the mini-browser or external browser tab window (it might take a few seconds for the server to recompile and load the changed application). When developing on your local computer using VSCode, you can make use of a hot-reload option (watch) that reduces the number of times you have to stop/start the server ``` $ dotnet watch --project SMS.Web```
    

2. In the ```Views\Home``` folder, open the ```Index.cshtml``` file, remove all existing content and add a ```<div>```. Inside this div create a ```<h1>``` containing text 'Home Page' and a ```<p>``` containing the text 'This is the default page displayed when the application loads'. Refresh the browser and navigate to the /Home route to see the changes.

3. Again modify the ```Index.cshtml``` file and add a second paragraph tag as outlined below. Note the use of the razor command (prefixed with @) to display current date/time in long date format 
   
   ```
   <p>Today is <b>@DateTime.Now.ToLongDateString()</b></p>
   ```

4. Generating data directly in the View is not a good idea. We want the view to be mostly html and contain the minimal amount of C# code. We therefore need some way to pass data to the View. One simple way is to use the controller ```ViewBag``` container. Open the ```HomeController.cs``` file located in the ```Controllers``` folder and modify the ```Index()``` action:
   
   * Add two new properties to the ViewBag, named ```LongTime``` containing current date/time formatted to a LongTimeString, and ```Message``` containing text "Time Now".
   
   * Modify the Index.cshtml file and add another ```<p>``` tag containing a message constructed using the ```@ViewBag.Message``` and ```@ViewBag.LongTime``` values. (note how we can access the elements placed in the Viewbag by the Index controller action using the @ razor syntax)


5. The second (and preferred way) we can pass data to the view is to use a model (either a Data model or a ViewModel). In this example we will create a ViewModel. Remember a ViewModel is just a model that contains a custom representation of the data for display in a view.
   
   - In the Models folder, create a new view model named AboutViewModel.cs, and add the following code. Note that it is just a plain C# class containing properties.
     
     ```
     using System;
     
     namespace SMS.Web.Models
     {
        public class AboutViewModel
        {
           public string Title { get; set; }
           public string Message { get; set; }
           public DateTime Formed { get; set; } = DateTime.Now;
           public string FormedString => Formed.ToLongDateString();
           public int Days => (DateTime.Now - Formed).Days;
        }
     }
     ```
   
   - Add a new Controller Action and View as follows: 
     
     - In the ```HomeController``` create a new Action method named ```About``` and in this method create an instance of the new ```AboutViewModel```, setting the Title, Message and Formed properties to values of your choice. The ```Formed``` property can be initialised using ```new DateTime(2022,1,1)``` ( 1st Jan 2022). Note if you don't supply a value for Formed then it defaults to the current DateTime. Finally return the View passing the viewmodel as a parameter. Review the notes and existing methods in the controller for guidance on creating an action.
     
     - Create a View in the ```Views\Home``` folder named ```About.cshtml``` to display the model properties. Use some suitable html elements and appropriate bootstrap components/styles to display the model data. Ensure you begin the .cshtml file with a declaration of the model type
       
       ```
       @model AboutViewModel
       
       <!-- place html content here -->

       ```
   
   * To view the new page, in the browser address bar, add ```/home/about``` to the end of the url 
   
   * Create an anchor tag in the Index.cshtml file which will navigate the user (when clicked) to the About page.
     

6. It would be more useful if each page contained a navigation menu that allowed us to navigate between routes (pages) rather than having to manually edit the url. 
   
   * Add suitable html to display a set of navigation links at top of each view, that when clicked would navigate to the Index page, the About page and the Privacy page respectively. A sample link might look as follows ```<a href="/home/index">Home</a>``` to navigate to the home page.
   
        ```Home``` ```About``` ```Privacy```
    
    * One thing to note is that we have to add the same html to each page (as we did previously in our practical on html). We will learn next week how we can use a layout to remove this restriction.

7.  ***OPTIONAL*** To allow us to edit a single project instance both locally using VSCode and in replit, we can make use of the Git source code management tool and the Github cloud repository. The overriding majority of software development companies would use Git/Github so this is a skill you need to learn. 

    - We should firsly create a ```.gitignore``` file using the following command in the replit version of the project ``` $ dotnet new gitignore```. This file will tell git to ignore any files that are not part of our project source code.
    - Next, follow the guidance notes in the week 0 notes and/or the Git/Github video in Blackboard.
