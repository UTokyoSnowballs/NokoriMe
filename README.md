# NokoriMe (https://nokori-me.azurewebsites.net/)
Credit to Lys Egholm Andersen, Zilu Liang

This app was developed based on SleepBeta (https://sleepbeta.azurewebsites.net) for a capstone project in the course "Web Development in Cloud" (https://snowballsutokyo.wordpress.com) in 2017 Fall.

NokoriMe helps users keep tracking their mental stress level using a digital diary. The diary contains 10 questions adapted from the validated Perceived Stress Scale (PSS) in psychology. It also integrate data from Fitbit devices, including sleep duration, steps, caloried consumption, physical activities, etc. The factors that correlate to stress will be highlighted (based on the calculation of Spearman correlation coefficients). 

NokoriMe was developed based on the ASP.NET MVC framework. You will need to fill in the database connection string and the Fitbit credential of your app (registered on Fitbit developer website) in the web.config file before you can deploy it. It's likely that you will also need to configure your database information in "PublishScripts\Configurations\SleepMakeSense-WAWS-dev.json".
