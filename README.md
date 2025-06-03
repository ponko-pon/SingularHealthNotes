To setup backend (.NET):
- Run dotnet run --launch-profile "DEV" (Assuming that you have the dotnet CLI installed)
- This launch profile should be set to host on http://localhost:5290

To setup frontend (Vue 3):
- Run npm install to install required dependencies.
- Run npm run dev
- This should be set to host on http://5173

  Notes:
  - No tests (Unit/Integration) are currently included in this prototype.
  - Simple validation is added.
  - Upon starting the backend application, it will automatically seed an in-memory cache with mock data. (Including scan image as assets that are served statically)
  - A simple repository is added for a subset of CRUD operations for the in-memory cache. (IMemoryCache is only limited to synchronous operations)
  - CORS is set to allow http://localhost:5173 access for the API.
  - Composition API is used for the Vue 3 frontend.
  - Uses axios to handle HTTP requests.
  - Uses Vuetify for frontend components.
 
  Time Spent:
  Approximately 2 hours. (120 minutes)
  Additional time taken due to unexpected issues with Vuetify. (The latest version was used and had some changes that I was not entirely familiar with)
