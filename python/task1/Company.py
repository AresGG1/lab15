class Company:

    def __init__(self, data):
        dataArray = data.split(',')
        name = dataArray[0]
        budget = dataArray[1]
        employees = dataArray[2]
        self.__name = name
        self.__budget = int(budget)
        self.__employees = int(employees)

    def get_name(self):
        return self.__name

    def get_budget(self):
        return self.__budget

    def get_employees(self):
        return self.__employees

    def set_name(self, name):
        self.__name = name

    def set_budget(self, budget):
        self.__budget = int(budget)

    def set_employees(self, employees):
        self.__employees = int(employees)

    def __str__(self):
        return f"{self.__name}, {self.__budget}, {self.__employees}"

    def __eq__(self, other):
        if self.get_name() == other.get_name() and self.get_budget() == other.get_budget() and self.get_employees() == other.get_employees():
            return True
        return False

    def __lt__(self, other):
        if self.get_name() < other.get_name():
            return True
        return False