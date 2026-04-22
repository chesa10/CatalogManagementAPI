### Installation
Step-by-step instructions to get a local development environment running.
1. Clone the repo:
   `git clone https://github.com/chesa10/CatalogManagementAPI`
2. This repo include both ANGULAR Frontend and the API project


# ANGULAR Project
-Provided that you have angular and Nodejs installed
-Run the following commands on cmd from this folder --> "\CatalogManagementAPI\CatalogManagementAPI\CatalogManagementAPI.Frontend"
-Commands to run:
	-npm config set legacy-peer-deps true
	-npm Install
	-ng serve -Please copy the url your angular is running on to Programe.cs located at the backend Project
		-Replace the parameter of this method "UseProxyToSpaDevelopmentServer()" in Programe.cs with your angular url
-Replace the "relativeUrl" value in environment.ts with the domain url of your API project

# API project
1. Update packages
2. Change the connection string ConnectionStrings in appsettingsDeveloment.json to your own ConnectionStrings
3. Run the following commands to create the database on your database server
4. Command to run:
	# add-migration new
    # update-database

### After all the settings above run ANGULAR project first and then API project.
