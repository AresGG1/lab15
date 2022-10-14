class Node:

    def __init__(self, data):
        self.data = data
        self.next = None


class LinkedList:

    def __init__(self):
        self.head = None

    def sort(self):
        arr = self.__to_array()
        arr.sort()
        self = self.__get_from_array(arr)
        return self

    def __to_array(self):
        tmp = self.head
        array = []
        while(tmp):
            array.append(tmp.data)
            tmp = tmp.next
        return array

    def __get_from_array(self, array):
        self.head = Node(array[0])
        tmp = self.head
        for i in range(1, len(array)):
            tmp.next = Node(array[i])
            tmp = tmp.next


    def contains(self, value):
        tmp = self.head
        while tmp:
            if tmp.data == value:
                return True
            tmp = tmp.next
        return False

    def count(self):
        count = 0
        tmp = self.head
        while tmp:
            count += 1
            tmp = tmp.next
        return count

    def show(self):
        tmp = self.head
        while tmp:
            print(tmp.data)
            tmp = tmp.next

    def insert_first(self, value):
        perv = self.head
        hd = Node(value)
        self.head = hd
        self.head.next = perv

    def insert_pos(self, value, position):
        if(position == 0):
            self.insert_first(value)
            return
        count = 0
        tmp = self.head
        while tmp:
            if position - 1  == count:
                next = tmp.next
                node = Node(value)
                node.next = next
                tmp.next = node
                break
            count += 1
            tmp = tmp.next

    def insert_last(self, value):
        count = 0
        tmp = self.head
        while tmp:
            if count == self.count()-1:
                tmp.next = Node(value)
                break
            count += 1
            tmp = tmp.next

    def clear(self):
        self.head = None

    def delete(self, index):
        count = 0
        tmp = self.head
        if index == 0:
            self.head = self.head.next
            return
        while tmp:
            if count == index-1:
                before = tmp
                after = tmp.next.next
                tmp = before
                tmp.next = after
                break
            tmp = tmp.next
            count += 1

    def delete_by_value(self, value):
        tmp = self.head
        if tmp.data == value:
            self.head = self.head.next
            return
        while tmp:
            if tmp.next.data == value:
                tmp.next = tmp.next.next
                return
            tmp = tmp.next

    def delete_all_by_value(self, value):
        tmp = self.head
        if tmp.data == value:
            self.head = self.head.next
            return
        while tmp:
            if tmp.next.data == value:
                tmp.next = tmp.next.next
            tmp = tmp.next
    def change(self, value, index):
        count = 0
        tmp = self.head
        while tmp:
            if count == index:
                tmp.data = value
                return
            count += 1
            tmp = tmp.next

    def change_all(self, old_value, new_value):
        count = 0
        tmp = self.head
        while tmp:
            if tmp.data == old_value:
                tmp.data = new_value
            count += 1
            tmp = tmp.next

    def find(self, option, value):
        tmp = self.head
        while tmp:
            if option == "name":
                if tmp.data.get_name() == value:
                    return tmp.data
            if option == "budget":
                if tmp.data.get_budget() == value:
                    return tmp.data
            if option == "employees":
                if tmp.data.get_employees() == value:
                    return tmp.data






if __name__ == "__main__":
    list = LinkedList()
    head = Node(1)
    list.head = head
    list.head.next = Node(1)
    list.change(1, 1)
    list.change_all(1,2)
    list.insert_last(5)
    list.insert_last(0)
    list.sort()
    list.show()
    list.find()