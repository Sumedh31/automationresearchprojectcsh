# Online Forms

User journeys related to approving submitted Online Forms from FE

## Table of Contents
1. [Scenario 1](#Scenario-1)
1. [Scenario 2](#Scenario-2)
1. [Scenario 3](#Scenario-3)
1. [Scenario 4](#Scenario-4)

## Scenario 1: <a name="Scenario-1"></a>

Field | Value
------------ | -------------
ID | Onlineforms_Approval_01
Form Name | Form1
Folder Name | Test Folder
Security | Full Control

User is able to go to Online forms and approve any form which is Pending approval

### Pre-Requisite:
* An Online form "form1" should be created from Admin with all fields added to the form under "Test Folder"
* Workflow used in form is "1 Step Approval"

### Steps:

* User navigates to Online forms and opens "Form1"
* Users fills in values for all fields and Submits the form
* User navigates to "My Forms" page - "Requires Review" tab
* User clicks on "Form1" and reviews it
* User selects the action "Approved" from "Next Step" field and Submits the form


## Scenario 2: <a name="Scenario-2"></a>

Field | Value
------------ | -------------
ID | Onlineforms_Approval_02
Form Name | Form1
Folder Name | Test Folder
Security | Full Control

User is able to go to Online forms and decline any form which is Pending approval

### Pre-Requisite:
* An Online form "form1" should be created from Admin with all fields added to the form under "Test Folder"
* Workflow used in form is "1 Step Approval"

### Steps:

* User navigates to Online forms and opens "Form1"
* Users fills in values for all fields and Submits the form
* User navigates to "My Forms" page - "Requires Review" tab
* User clicks on "Form1" and reviews it
* User selects the action "Declined" from "Next Step" field and Submits the form

## Scenario 3: <a name="Scenario-3"></a>

Field | Value
------------ | -------------
ID | Onlineforms_Approval_03
Form Name | Form1
Folder Name | Test Folder
Security | Full Control

User is able to go to Online forms and mark any form "Requires Changes" which is Pending approval

### Pre-Requisite:
* An Online form "form1" should be created from Admin with all fields added to the form under "Test Folder"
* Workflow used in form is "1 Step Approval (Revisions Allowed)"

### Steps:

* User navigates to Online forms and opens "Form1"
* Users fills in values for all fields and Submits the form
* User navigates to "My Forms" page - "Requires Review" tab
* User clicks on "Form1" and reviews it
* User selects the action "Requires Changes" from "Next Step" field and Submits the form


## Scenario 4: <a name="Scenario-4"></a>

Field | Value
------------ | -------------
ID | Onlineforms_Approval_04
Form Name | Form1
Folder Name | Test Folder
Security | Full Control

User is able to go to Online forms and makes changes to any of his submitted forms which requires changes and submit.

### Pre-Requisite:
* An Online form "form1" should be created from Admin with all fields added to the form under "Test Folder"
* Workflow used in form is "1 Step Approval (Revisions Allowed)"

### Steps:

* User navigates to Online forms and opens "Form1"
* Users fills in values for all fields and Submits the form
* User navigates to "My Forms" page - "Requires Review" tab
* User reviews "Form1" and selects the action "Requires Changes" from "Next Step" field and Submits the form
* User navigates to "My Forms" page -> My Submissions tab
* User loads "form1" and makes neccessary changes and submits the form
