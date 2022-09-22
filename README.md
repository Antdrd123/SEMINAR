# Term paper



> ASP.NET developer course final project

---

### Table of Contents
You're sections headers will be used to reference location of destination.

- [Description](#description)
- [How To Use](#how-to-use)
- [References](#references)
- [Author Info](#author-info)

---

## Description
Final project called Algebra_Seminar_Drdic is simple webshop with basic functions and few different roles. Application is connected with database and should be used locally on PCs.

#### Technologies

- C#
- HTML
- CSS
- Entity Framework
- .NET

[Back To The Top](#read-me-template)

---

## How To Use

#### Installation
This project consists of one solution with two projects(Algebra_Seminar_Drdic and API). When in project, first you have to change DefaultSettings in appsettings.json to your server in BOTH projects. If necessary, leave "TrustedConnection=true", depending on your local properties. After that, you should be set to start the app.

#### Application functions
Application has two different roles of "User" and "Admin" that have different authorization. User has to be logged in, can see ten random products and their details. Admin, on the other hand, can see everything that User can, has authorization over basic CRUD functions for category, product and account. 

#### API Reference
With the help of the REST WEB API, use of the endpoints was enabled on which 
XML or JSON format are able to access all products or
individual product by database code.
```html
    <p>/api/ApiProduct</p>
    <p>/api/ApiProduct/{id}</p>
```
[Back To The Top](#read-me-template)

---

## References
<a id="1">[1]</a> 
Troelsen, A., Japikse P. (2021). 
Go to statement considered harmful. 
Communications of the ACM, 11(3), 147-148.

[Back To The Top](#read-me-template)

---



## Author Info

- GitHub - (https://github.com/Antdrd123)
- Mail - antoniodrdic7@gmail.com

[Back To The Top](#read-me-template)
