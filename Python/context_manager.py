class Worker:
    def __init__(self):
        pass

    def __enter__(self):
        print('Object has been initialized...')

    def __exit__(self, type, value, traceback):
        print('Object has been disposed...')


with Worker() as worker:
    print('Doing something with initialized object...')
    pass