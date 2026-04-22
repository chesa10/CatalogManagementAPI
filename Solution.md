I implement the solution using Clean Architeture which which resulted in the following tradeoffs

Key Tradeoffs
Complexity vs. Flexibility: Clean Architecture uses multiple layers (Domain, Application, Infrastructure, Presentation) to decouple concerns. 
While this makes swapping external services easier, it often requires you to create numerous interfaces and DTOs just to pass data between layers, which can feel like "over-engineering" for simpler projects.

Development Velocity: Initial setup is slower. Implementing a single feature often requires touching 4–5 different projects or folders in your C# solution.
For small CRUD applications, this can reduce delivery speed by 30–40% compared to simpler patterns like MVC.
Performance Overhead: The heavy use of abstractions and the need to map between Domain Entities, Persistence Models, and DTOs can introduce a minor performance hit 

New developers may find the strict "Dependency Rule" (inner layers cannot know about outer layers) confusing at first, leading to a steeper onboarding process compared to traditional N-Tier architectures

For Product search engine I used:
IQueryable<T> because it allows LINQ queries to be translated into SQL and executed directly on the database (e.g., Entity Framework), 
fetching only necessary filtered data to improve performance. Its main benefit is optimizing data access for large datasets, 
while the primary tradeoff is potential performance issues from lazy evaluation, complex SQL generation, and leaking DAL logic




