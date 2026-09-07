# Drinks Menu Console Application - Atizzle07

**Description:**

A console based API viewer based on the [cocktails database](www.thecocktaildb.com/api.php). 


## Features:
----
#### Splash Screen
- This is the entry point for the application and prompts the user to begin by pressing Enter
- Utilizes the Spectre console Figlet for a nice title bar which persists across the application

<img width="1339" height="553" alt="image" src="https://github.com/user-attachments/assets/8c4e6e3b-dc94-49d7-be5e-4abb37310048"/>

#### Category Selection
After entering the application, an HTTP client is created and gets the category list from the API to present to the user. It utilizes the Spectre Console SelectionPrompt for guided navigation

<img width="1336" height="561" alt="image" src="https://github.com/user-attachments/assets/06eea1ac-fd04-4450-9772-82e64e8b1ffa" />

#### Drink Selection
After the user selects a category, the selection is passed back to the API to get a list of matching drink names and is displayed at the top of the response screen. To aid in selection, I invoked the 'search' function in Spectre which highlights typed text. This does have limited functionality (Only shows selection for one item and does not support moving between matching items) but is still useful if you somewhat know what you are looking for.

<img width="1335" height="593" alt="image" src="https://github.com/user-attachments/assets/7d8c34fc-91f4-4c6c-a641-938ca0b547db" />
<img width="601" height="584" alt="image" src="https://github.com/user-attachments/assets/67ba368c-0b72-4bc0-b1bd-9057bd83a600" />


#### Recipe View
- When a drink is selected the recipe ID is passed to the API and the JSON response mapped to a DTO, then to a RecipeResponse object. This is then filtered and formatted into table and text responses shown below (again using Spectre).
- To provide a seamless app experience, the user is then prompted with 3 options: Exit, select a new category, or select a new drink from the same category. This takes them back through the same menus shown before in a loop.

<img width="818" height="881" alt="image" src="https://github.com/user-attachments/assets/b294a70c-3923-4777-b6e3-29c27f328099" />

## Lessons learned
----
- HTTP requests and utilizting DTO's to transform the responses into C# objects with Newtonsoft 
- Cascading console menu calls with forward and backward navigation
- Spectre Console library for showing a more polizhed and user friendly console experience
- Utilizing multiple "Projects" inside a single solution to separate concerns
- Newtonsoft for JSON deserialization
- Utilizing Postman to map out API calls

## Challenges
----
- Working with DTO's and nested JSON response objects took a little bit of fiddling to get right. I initially didn't notice that the recipe for a single drink came back under a drink object, not just the recipe, so I spent a lot of time wondering why my JSON response was not deserializing properly. Definitely a 'DUH' moment!
- This was one of the longest applications I have made so far. I did code the first 2/3 of the project a few months ago and picked it up recently to finish in a weekend. This isn't the best method because I had to relearn everything but I also think that in itself was a good opportunity to learn an unfamiliar codebase (even though it was me that wrote it). I always struggled with this concept so that was a giant fringe benefit.

## Resources Used
----
- Spectre Console Library documentation
- Google search, including the "AI Mode"
- Microsoft Learn articles
- ChatGPT (I did not use Codex to write code for me, this was entirely hand-typed. I mainly used this resource to help with a few design decisions and some bugs that I could not figure out)
