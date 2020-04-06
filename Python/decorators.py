from time import time

def timer(func):
    def inner(*a, **kw):
        started = time()
        rv = func(*a, **kw)
        print(f'Elapsed: {time() - started}')
        return rv
    return inner

@timer
def add(*a):
    s = 0
    for x in a:
        s += x
    print(s)

@timer
def multiply(*a):
    s = 1
    for x in a:
        s *= x + 2
        s /= x + 1
    print(s)

def my_new_range(*a):
    for x in a:
        yield x**2



for x in my_new_range(*(x for x in range(0, 11, 5))):
    print(x)

# add(*(x for x in range(10**7)))
# multiply(*(x for x in range(10**7)))