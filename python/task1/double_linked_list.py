class DoubleNode:

    def __init__(self, data):
        self.data = data
        self.next = None
        self.prev = None


class DoubleLinkedList:

    def __init__(self):
        self.head = None

    def sort(self):
        arr = self.__to_array()
        arr.sort()
        self = self.get_from_array(arr)
        return self

    def __to_array(self):
        tmp = self.head
        array = []
        while(tmp):
            array.append(tmp.data)
            tmp = tmp.next
        return array

    def get_from_array(self, array):
        self.head = DoubleNode(array[0])
        tmp = self.head
        for i in range(1, len(array)):
            tmp.next = DoubleNode(array[i])
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
        if self.head == None:
            self.head = DoubleNode(value)
            return
        prev = self.head
        hd = DoubleNode(value)
        prev.prev = hd
        self.head = hd
        self.head.next = prev
        self.head.prev = None

    def insert_pos(self, value, position):
        if(position == 0):
            self.insert_first(value)
            return
        count = 0
        tmp = self.head
        while tmp:
            if position - 1 == count:
                next = tmp.next
                prev = tmp
                node = DoubleNode(value)
                node.next = next
                node.prev = tmp
                tmp.next = node
                break
            count += 1
            tmp = tmp.next

    def insert_last(self, value):
        if self.head == None:
            self.head = DoubleNode(value)
            return
        count = 0
        tmp = self.head
        while tmp.next:
            tmp = tmp.next
        prev = tmp
        tmp.next = DoubleNode(value)
        tmp.next.prev = tmp

    def clear(self):
        self.head = None

    def delete(self, index):
        count = 0
        tmp = self.head
        if index == 0:
            self.head = self.head.next
            self.head.prev = None
            return
        if index == self.count()-1:
            tmp = self.head
            while tmp.next:
                tmp = tmp.next
            tmp.prev.next = None
            return

        while tmp:
            if count == index-1:
                before = tmp
                after = tmp.next.next
                tmp = before
                tmp.next = after
                tmp.next.prev = before
                break
            tmp = tmp.next
            count += 1

    def delete_by_value(self, value):
        tmp = self.head
        if tmp.data == value:
            self.head = self.head.next
            self.head.prev = None
            return
        count = 0
        while tmp:
            if tmp.data == value:
                self.delete(count)
                return
            tmp = tmp.next
            count += 1

    def delete_all_by_value(self, value):
        tmp = self.head
        if tmp.data == value:
            self.head = self.head.next
            self.head.prev = None
        tmp = self.head
        count = 0
        while tmp:
            if tmp.data == value:
                self.delete(count)
                count = 0
                tmp = self.head
                continue
            tmp = tmp.next
            count += 1

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
            if option == "universityName" or option == "university name":
                if tmp.data.get_university_name() == value:
                    return tmp.data
            if option == "employees":
                if tmp.data.get_employees() == value:
                    return tmp.data
            tmp = tmp.next

    def write(self):
        data = self.__to_array()
        st = ""
        for i in data:
            st += str(i)
            st += "\n"
        fstream = open(file="task1_2.txt", mode="w")
        fstream.write(st)
        fstream.close()
        print('Write success')


if __name__ == "__main__":
    list = DoubleLinkedList()
    list.insert_last(11)
    list.insert_last(12)
    list.insert_last(13)
    list.insert_pos(10, 3)
    list.insert_pos(10, 3)
    list.delete_all_by_value(10)
    # list.delete(3)
    list.show()