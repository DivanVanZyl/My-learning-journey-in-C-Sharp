using AlgTester.API;//Include lib
using HackerrankTest;

// Save the function you want to test in a variable (it will help C# auto resolve the correct method call)
var solutionFunc = Solution.MyCodingChallengeSolution;
// Run your tests
SolutionTester.New()
    .WithSolution(solutionFunc)
    .WithTestCase(2, new int[] { 1, 3 }, 0) // Type safe Input and output
    .WithTestCase(3, new int[] { 2, 3, 5 }, 1) // Another test case (this one will fail)
    .WithTestCase(3, new int[] { 2, 3, 5 }, 0) // and another :)
    .Run();//Run tests!