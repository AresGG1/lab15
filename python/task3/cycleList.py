import random


class Node:

    def __init__(self, data):
        self.data = data
        self.next = None
        self.prev = None


class CycleList:

    def __init__(self):
        self.head = None

    def append(self, value):
        if self.head == None:
            self.head = Node(value)
            return
        if self.head.next == None:
            self.head.next = Node(value)
            self.head.prev = self.head.next
            self.head.next.next = self.head
            self.head.next.prev = self.head
            return
        tmp = self.head
        while tmp.next != self.head:
            tmp = tmp.next
        tmp.next = Node(value)
        tmp.next.prev = tmp
        tmp.next.next = self.head
        self.head.prev = tmp.next

    def count(self):
        tmp = self.head
        count = 0
        while tmp.next != self.head:
            tmp = tmp.next
            count += 1
        return count + 1

    def pop(self, index):
        if index == 0:
            res = self.head.data
            last = self.head.prev
            self.head = self.head.next
            self.head.prev = last
            return res

        if index >= self.count():
            raise Exception("Incorrect index")
        count = 0
        tmp = self.head
        while count != index:
            tmp = tmp.next
            count += 1
            # print(tmp)
        result = tmp.data
        newPrev = tmp.prev
        newNext = tmp.next
        newPrev.next = newNext
        newNext.prev = newPrev
        return result
if __name__ == "__main__":
    Surnames = {"Мельник", "Шевченко", "Коваленко", "Бондаренко", "Бойко", "Ткаченко", "Кравченко", "Ковальчук", "Коваль",
                "Олійник", "Шевчук", "Поліщук", "Ткачук", "Савченко", "Бондар", "Марченко", "Руденко", "Мороз", "Лисенко",
                "Петренко", "Клименко", "Павленко", "Кравчук", "Кузьменко", "Шило"}
    cycled1 = CycleList()
    cycled2 = CycleList()
    for i in range(10):
        cycled1.append(Surnames.pop())
        cycled2.append(Surnames.pop())
    for i in range(10):
        print(f"{cycled1.pop(random.randint(0,cycled1.count()-1))} VS {cycled2.pop(random.randint(0,cycled2.count()-1))}")

