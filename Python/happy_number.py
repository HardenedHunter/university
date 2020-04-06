# class Solution:
#     def square_digits(self, n):
#         return sum(int(c) ** 2 for c in str(n))
    
#     def isHappy(self, x: int) -> bool:
#         forbidden = [1, 4, 16, 37, 58, 89, 145, 42, 20]

#         while x not in forbidden:
#             x = self.square_digits(x)
#         return x == 1

class Solution:    
    def isHappy(self, x: int) -> bool:
        s = set([1])
        while x not in s:
            s.add(x)
            x = sum(int(c) ** 2 for c in str(x))
        return x == 1

# 89
# 145
# 42
# 20
# 4
# 16
# 37
# 58
