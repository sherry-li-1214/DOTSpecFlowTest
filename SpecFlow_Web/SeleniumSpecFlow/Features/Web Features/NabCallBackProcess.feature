@ui
Feature: Loan Query appointment test on Nab Website
UI Test for NAB website 
 
    Background: 
 
	@Web
	Scenario: Test the call back process
		Given I enter into Nab Website
		Then I want to book an appointment 
		Then I need choose the options for questions on the page  
		  | Reason            | applications number | Income Come From             | Deposit Come From |
		  | Buying a property | 2 to 5 applicants   | Full or part-time employment | Money Saved       |
        Then  I fill in suburb information 
        Then I select my preferred appointment type with Over the Phone
        Then I select appointment date with following information
         | Date       | Time    |
         | 20220211   | 10:00am |
        Then I fill in my detailed contact information for the appointment
        Then I confirm and book the appointment with the information from /testdata/personal_info.xlxs
        Then I should go to confirmation page with appointment details