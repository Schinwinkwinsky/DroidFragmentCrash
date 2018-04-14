# DroidFragmentCrash

This is a repository where I can reproduce the problem that I'm facing on Xamarin Forms on Android. The app was tested on iOS and didn't show the problem.

# Run the App

There's a simple Web API that you can run through terminal with:

- folder-to-web-api-project-folder/dotnet run

You need to have the Dotnet Core 2.0 or later installed on the computer.

To run the Android project I used the Genymotion emulator.

# The Crash

The app goes to the ShowValuesPage that shows a list of values obtained from the Web API. If the user is not authorized, the app goes to SignInPage. If the user doesn't have an account he can go to SignUpPage. There, he needs to accept to contract at ContractPage. When the user do the sign up, the app get a authorization token from the Web API. Then the app goes to ShowValuesPage again to get the values. But when it tries to access the Web API again, the exception is thrown.

Exception: Java.Lang.IllegalArgumentException - No view found for id (some address) for fragment FragmentContainer.