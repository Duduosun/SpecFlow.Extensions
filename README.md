# SpecFlow.Extensions
extensions for SpecFlow and Selenium

# Key Features
* <b>Automapper</b> - can be used to automatically fill in PageObjects, Contexts, and other test objects using SpecFlow tables from Feature files or other objects (you could use a Context to fill in a PageObject, for example). For clarification, contexts are the objects that are passed into StepDefinition/Hook classes when using Context Injection.

* <b>Tests should require fewer explicit waits</b> - the framework handles a lot of "timeout", "timing cracks", "invalid state", "stale element", and "not found" issues using smart or implicit waits. This reduces the need to use hardcoded or explicit waits in test code. Few waits means less code. Less code means less bugs. Less bugs means more reliable and maintainable automation.

* <b>Test Suite of "badly" behaving html pages</b> - you can use the sample of "bad" html pages to compare this framework to your own (two frameworks enter, one framework leaves). These pages are designed to expose gaps in automation frameworks (they will break you... on purpose). Also, they serve as an example as to how to use this framework.
<ol><b><u>Example "bad" pages:</u></b>
<li>open and close slow modals</li>
<li>modals that switch pages</li>
<li>slow drop down lists</li>
<li>slow grids that load large data sets</li>
<li>pages that refresh</li>
<li>collapsing and expanding elements</li>
</ol>

* <b>Database Helper</b> - not a replacement for a DAL or api...but a lot of times you don't even have that so having a convenient way to work with SQL statements can come in handy every now and then.

* <b>String Extensions and Randomize</b> - some common string manipulation and randomization methods

* <b>ComparisonMismatch</b> - helps keep your Assert statements in your Thens and also allows you to show all "mismatches" instead of failing on the first mismatch. Use ComparisonMismatch as you would Assert.AreEqual() [etc.] and then, for the final assert in your Then, use Assert.IsEmpty(myComparisonMismatch.Mismatches()) to get a list of all the mismatches.

* <b>Empty Scenarios fail</b> - if a scenario has no steps, it will fail instead of pass

* <b>Example WebDriverHooks</b> - browser windows can be maxmized, minimized for smaller screens, reused, closed after scenarios, and so on by using hooks in feature files

* <b>Templates for building PageFactory, DriverFactory, WebDriver wrappers (PortalDriver for your AUT), etc.</b>

* <b>Tester objects</b> - embed hashes in test data that can be used to identify which tests created it, external JSON files for user credentials (login using roles instead of hardcoded username/password for maintainable/scalable feature files), tester emails based on machine name so that the "current tester" receives email alerts instead of a hardcoded email address, etc.

* <b>WaitForPageLoad, WaitForUrlToChange, WaitForElement, FindElementOrNull</b>

* <b>extended Bys</b> to find by Attribute (single or list), Column, or Text

# Use

This project will be a container for the SpecFlow / Selenium extension code that I develop while
using said software tools. Too often I find myself looking up webdriver code on the internet and I'd
like to keep everything I use in one convenient and portable library (for future use of course).

# Framework

For starters, this is not a "plug-and-play one size fits all" test framework. This is a "modify and 
integrate into your test environment" test framework. That said, you'll most likely have to create
and fill in code to get portions of SpecFlow.Extensions to work for your particular situation. It is,
however, IMHO, a good place to start. I prefer to consider it a toolkit.
