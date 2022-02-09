# UI and API AUTOMATION USING BDD FRAMEWORK

Contents:

1. Purpose of UI and API Automation Framework.
2. Overview
3. Framework structure
4. Packages used
5. How to Run it 

## Purpose of SpecFlow  Automation Framework:

The purpose for this automation framework is to serve a technical implementation guideline for automation testing. With the help for BDD implementation this framework not only helps to reuse the code but also helps to set standard for test scripts.This framework created as a part of the challenge to facilitate the API and UI both together.

## Overview:

To automate UI and API this framework uses SpecFlow which is a testing framework that supports Behaviour Driven Development (BDD).

There are three libraries created which are:
Api Library – used to write the API functional and helper logic
Web Library – used to write the API functional and helper logic
Test Library – used to write the BDD-Feature, Step Definitions, Utilities, Core framework and Reporting

## Framework structure:


### 1. ApiLibrary
All the API related class and libraries to run httpRequest and httpResponse .

### 2. SeleniumSpecFlow Folder:

All the feature files , step definition files,hooks and utilities (Driver Factory and Object Factory,Reporting util) are kept under the Test folder. These tests are described here in a simple English language called as Gherkin language.
Test Results and screenshots are also kept here.

Folders inside:
#### Features
* API Features/ReqRes.feature is API tes case
* Web Features/NabCallBackProcess.feature is for Web bases UI Test
#### Hooks
#### Steps
#### TestResults
#### Utitlies

Files:
####AppSettings.json: The configuration files for the testing. It include Home Url(nab.com.au) and API Test Url.


### 3. WebLibrary:

This folder contains the pageojbect class and file for the tests which helps to organize all page elements.

## Packages used:

Microsoft.AspNet.WebApi.Client, Version: 5.2.7 NUnit, Version: 3.12.0 Newtonsoft.Json, Verison: 12.0.2 Specflow, Version: 2.3.2 ExtentReports, Version: 3.1.3

##Tools: 
C# Specflow Selenium Use JetBrains Rider for Best Experience

## How TO Run it

### Option 1: In IDE
In Visual studio , go to test exlorer and run all tests.
In JetBrains Rider, go to build and build the solution. Then run "Unit tests" for all.

### Option 2 :In Command line 

Now that SpecFlow 3.0 has been released we can use SpecFlow with .NET Core. The CLI tool for .NET Core is dotnet and tests are run like this if you use MSTest (vstest):

* dotnet test
If the tests are in a specific project you can specify the project like this

* dotnet test TestProject
where TestProject is the name of the project. You can skip the project name if you want to, but specifying it will make dotnet look in only that project. To list all the tests in the project you can use the -t flag:

* dotnet test TestProject -t
To run only specific tests you can use the --filter flag:

dotnet test TestProject --filter @api  (for api test)
dotnet test TestProject --filter @ui  (for ui test)

## Logs and Test Reports

Reporting can be found in the below location and same has been attached 
Reports Location: ~..SpecFlow_Web-Api\SeleniumSpecFlow\TestResults\Report\index.html. It is a pretty good Reports which can provide dashboard and analysis for test exectuion status.
Failed Cases Screenshot:  .SpecFlow_Web-Api\SeleniumSpecFlow\TestResults\Img

