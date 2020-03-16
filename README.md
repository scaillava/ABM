# ABM

1) In the first point, I did a generic parser library of EDIFACT text. 
After that, to resolve the specific problem of extract second and third columns of LOC segment just used the generic parser that I mentioned before in a console app.
I used dependency injection and also added NUnit.

2&3) I figured out that both XML has the same structure, so I generate a Schema using Visual Studio with the file.xml open -> XML tab -> Create Schema.
With that, I got the file DeclarationList.xsd and with this file, I generate a class DeclarationList.cs to deserialize using the command:

`xsd DeclarationList.xsd /classes`
>https://stackoverflow.com/questions/4203540/generate-c-sharp-class-from-xml

After that, I change the original DeclarationList.xsd because in the 3rd problem I could see that the elements <Reference> are optatives, and elements like <Declaration>, <SiteID>, <DeclarationHeader> so I changed the minOccurs values depending on if it's required.

With this xsd, I validate the structure in both problems, and if it is correct I deserialize using XmlSerializer and the generated class DeclarationList.cs
2)
Added Unit test using NUnit
3)
Added Integration test using XUnit

