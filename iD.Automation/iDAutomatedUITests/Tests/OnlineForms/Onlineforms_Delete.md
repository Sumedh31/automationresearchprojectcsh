# Online Forms

User journeys related to deleting a submitted Online Forms from FE

## Table of Contents
1. [Scenario 1](#Scenario-1)
1. [Scenario 2](#Scenario-2)

## Scenario 1: <a name="scenario-1"></a>

Field | Value
------------ | -------------
ID | OnlineForms_Delete_01
Form Name | Form1
Folder Name | Test Folder
Security | Full Control

User is able to go to Online forms and delete any submission (Permissions required) and view the deleted item in recycle bin

### Pre-Requisite:
* An Online form "form1" should be created from Admin with all fields added to the form under "Test Folder"

### Steps:

* User navigates to Online forms and opens "Form1"
* Users fills in values for all fields and Submits the form
* User navigates to Submissions.aspx by clicking on Submissions count
* User selects a form and selects "Delete" action.
* User clicks on "Recycle Bin" in links section and can view deleted items in Recycle Bin

## Scenario 2: <a name="scenario-2"></a>

Field | Value
------------ | -------------
ID | OnlineForms_Delete_02
Form Name | Form1
Folder Name | Test Folder
Security | Full Control

User is able to go to Online forms and undelete any deleted form (Permissions required) from recycle bin

### Pre-Requisite:
* An Online form "form1" should be created from Admin with all fields added to the form under "Test Folder"
* Any deleted submissions should be present in recycle bin

### Steps:

* User navigates to Online forms and navigates to "Test folder"
* User selects "form1" radio button and clicks on "Recycle Bin" action
* User selects a deleted entry and selects "Undelete" action


