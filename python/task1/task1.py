import linked_list
from Company import Company

def from_file():
    res = []
    fstream = open(file="task1_1.txt", mode="r")
    dataArr = fstream.read().split('\n')
    for i in dataArr:
        try:
            if i != '':
                ent = Company(i)
        except:
            raise Exception('saksakka')
        res.append(ent)
    return res

while True:
    ans = input('1. Single linked list\n2. Double linked list')
    if ans == "1":
        list = linked_list.LinkedList()
        print('Вставка в кінець: ')
        list.insert_first(Company('name1, 121121, 111'))
        list.show()
        print('Вставка на початок: ')
        list.insert_first(Company("Volkswagen,30000100, 24000"))
        list.show()
        print('Вставка в довільну позицію: ')
        list.insert_pos(Company("Silpo,200000, 13111"), 1)
        list.show()
        print('Редагування значення: ')
        list.change(Company("IBM, 11010000, 1110"), 2)
        list.show()
        print("Перевірка на відсутність: ")
        print("is IBM, 11010000, 1110 in list: ")
        print("Yes" if list.contains(Company("IBM, 11010000, 1110")) else "No")
        print("Кількість елементів: " + str(list.count()))
        list.insert_last(Company("IBM, 11010000, 1110"))
        list.show()
        print("Заміна всіх за значенням: ")
        list.change_all(Company("IBM, 11010000, 1110"), Company("Apple,302122020, 200201"))
        list.show()
        print("Пошук за значенням (IBM): ")
        print(list.find("name", "Apple"))
        print('Сортування: ')
        list.sort()
        list.show()
        print("Запис у файл: ")
        list.write()
        print('Видалення по ідексу: ')
        list.insert_last(Company("IBM, 11010000, 1110"))
        list.show()
        list.delete(4)
        list.show()
        print('Видалення по значенню: ')
        list.delete_by_value(Company("Silpo,200000, 13111"))
        print('Видалення по всіх значенню: ')
        list.delete_all_by_value(Company("Apple,302122020, 200201"))
        list.show()
        list.clear()
        print("Кількість елементів: " + str(list.count()))
        list.get_from_array(from_file())
        list.show()


    elif ans == "2":
        pass
    else:
        break