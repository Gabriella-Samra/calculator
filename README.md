# Project purpose

1. To create a basic calculator that can handle 2 operands and an operator, producing a calculation
2. Do this as a console app first
3. Extend this to handle expressions in the following order of complexity:
    1. Allow the user to type a single operator and operand combination, i.e. 1 + 2
    2. Allow only chains of non-parenthesised, non-exponential expressions i.e. 1+2+3, with no 1+(2+3)
    3. Allow exponential expressions, i.e. 1^2
    4. Allow negative numbers in the expression
    5. Allow parenthetical expressions with exponents, i.e. 1+(2^3)
    6. Allow parenthesis to be treated in an algebraic way ie. 2(2^3) = 16
4. Repurpose into an API
5. Add an SPA frontend

# Notes to self

To create a new console application:

1. Open the terminal (`ctrl + shift + s` or `Terminal -> New Terminal` in head)
2. Run the create console app dot net core command (`dotnet new console`)
3. Run the app its generated by either running it at the terminal (`dotnet run`) or pressing the run button in the top right of the editor