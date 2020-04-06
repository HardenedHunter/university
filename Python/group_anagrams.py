# from collections import defaultdict

# class Solution:
#     def charCount(self, word: str):
#         d = defaultdict(int)
#         for c in word:
#             d[c] += 1
#         return d
            
    
#     def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
#         d = defaultdict(list)
#         for s in strs:
#             key = tuple(self.charCount(s).sorted())
#             d[key].append(s)
#         return d