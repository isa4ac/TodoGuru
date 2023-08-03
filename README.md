# TodoGuru
A to-do list app made with Xamarin.forms
[Submission Requirements]
# You are required to submit the archive of the complete project/solution. (160 points)
# You are required to write documentation covering the below points. (40 points)
# Title of the Project (5 points) 
# Group member's names (5 points)
Names: Guy-Leroc Ossebi, Isaac Van Meter,Modupeoluwa Daniel

Introduction: What is the problem you are addressing and how are you addressing it. Identify the audience or users of this application. (10 points)
Skills: What are the technical skills you needed to develop the application, what are the tools or APIs (Platform specific and third party) used in the project? (10 points)
Project contributions: Identify the contributions of all the group members. (10 points)
Only one member of the group needs to submit the project.

Title: TodoGuru - Task Management Application

Introduction:
TodoGuru is a task management application designed to help users efficiently organize and track their tasks. The app allows users to create tasks, set due dates, add descriptions, and categorize their tasks. With a simple and user-friendly interface, TodoGuru aims to streamline task management for individuals across various domains, including students, professionals, and homemakers.

Audience or Users:
The target audience for TodoGuru includes individuals who seek a straightforward and effective tool to manage their tasks. Students can use the app to keep track of assignments and project deadlines. Professionals can organize work-related tasks and prioritize activities. Homemakers can manage household chores and errands with ease. The application caters to users who prefer a convenient and intuitive task management system without unnecessary complexity.

Skills and Tools:
The development of TodoGuru required a range of technical skills and tools:
1. C#: The primary programming language used to build the Xamarin.Forms application.
2. Xamarin.Forms: A cross-platform mobile app development framework used to create the app for both Android and iOS platforms using a single codebase.
3. XAML (eXtensible Application Markup Language): Used to design the user interfaces for pages such as "AddTaskPage," "MainPage," and "CategoryPage."
4. SQLite: Implemented as the local database solution to store and manage user tasks on the device.
5. LINQ (Language-Integrated Query): Employed to query and group tasks based on their categories, facilitating the creation of the "CategoryTask" class.

Project Contributions:
The project's success was the result of collaborative efforts from all group members:
1. Member Modupeoluwa Daniel:
   - Designed the user interface (XAML) for the "AddTaskPage."
   - Integrated the task list into the "MainPage" using a "CollectionView."
   - Worked on "MainPage.xaml.cs" to implement navigation between pages and ensure proper data flow.

2. Member Isaac Van Meter:
   - Developed the "Task" class, defining the structure of individual tasks.
   - Debugged and tested the application to resolve issues.
   - Developed the database class ("Database.cs") and integrated SQLite for data storage.
   - Implemented basic CRUD operations for task management.

3. Member Guy-leroc Ossebi:
   - Designed the user interface (XAML) for the "CategoryPage," implementing the "Picker" for category selection and the "CollectionView" for grouped task display.
   - Worked on the "CategoryTask" class, facilitating the grouping of tasks by categories.
   - Collaborated on "MainPage.xaml.cs" to implement navigation between pages and ensure proper data flow.
   - Ensured the proper flow of data between pages, allowing users to view tasks grouped by category.

Together, we combined our skills and contributions to create TodoGuru, a functional and user-friendly task management application. The team's efforts resulted in a valuable tool for individuals to efficiently organize and manage their tasks, ultimately improving productivity and task completion.

