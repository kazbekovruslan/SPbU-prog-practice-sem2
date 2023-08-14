[1mdiff --git a/finaltest1.1/SparseVector/SparseVector/SparseVector.cs b/finaltest1.1/SparseVector/SparseVector/SparseVector.cs[m
[1mindex 04025cf..6fa0656 100644[m
[1m--- a/finaltest1.1/SparseVector/SparseVector/SparseVector.cs[m
[1m+++ b/finaltest1.1/SparseVector/SparseVector/SparseVector.cs[m
[36m@@ -11,12 +11,12 @@[m [mpublic static class SparseVector[m
     /// <param name="firstVector">First sparse vector.</param>[m
     /// <param name="secondVector">Second sparse vector.</param>[m
     /// <returns>Result of addition of two sparse vectors.</returns>[m
[31m-    public static List<(int, int)> Add(List<(int, int)> firstVector, List<(int, int)> secondVector)[m
[32m+[m[32m    public static List<(int, int)> Add(List<(int index, int value)> firstVector, List<(int index, int value)> secondVector)[m
     {[m
         List<(int, int)> result = new();[m
 [m
[31m-        var lastPosOfFirstVector = firstVector.Last().Item1;[m
[31m-        var lastPosOfSecondVector = secondVector.Last().Item1;[m
[32m+[m[32m        var lastPosOfFirstVector = firstVector.Last().index;[m
[32m+[m[32m        var lastPosOfSecondVector = secondVector.Last().index;[m
 [m
         if (lastPosOfFirstVector != lastPosOfSecondVector)[m
         {[m
