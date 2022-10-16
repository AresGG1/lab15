import linked_list
import double_linked_list
from Company import Company
from UniversityUnit import UniversityUnit


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

def from_file2():
    res = []
    fstream = open(file="task1_2.txt", mode="r")
    dataArr = fstream.read().split('\n')
    for i in dataArr:
        try:
            if i != '':
                ent = UniversityUnit(i)
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
        list = double_linked_list.DoubleLinkedList()
        print('Вставка в кінець: ')
        list.insert_first(UniversityUnit('name1, CHNU, 111'))
        list.show()
        print('Вставка на початок: ')
        list.insert_first(UniversityUnit("History faculty,CHNU, 100"))
        list.show()
        print('Вставка в довільну позицію: ')
        list.insert_pos(UniversityUnit("Comp science,Lviv Politeh, 30"), 1)
        list.show()
        print('Редагування значення: ')
        list.change(UniversityUnit("Philosophy, CHNU, 20"), 2)
        list.show()
        print("Перевірка на відсутність: ")
        print("is Philosophy, CHNU, 20 in list: ")
        print("Yes" if list.contains(UniversityUnit("Philosophy, CHNU, 20")) else "No")
        print("Кількість елементів: " + str(list.count()))
        list.insert_last(UniversityUnit("Philosophy, CHNU, 20"))
        list.show()
        print("Заміна всіх за значенням: ")
        list.change_all(UniversityUnit("Philosophy, CHNU, 20"), UniversityUnit("Philosophy, KNTEU, 9"))
        list.show()
        print("Пошук за значенням (Philosophy): ")
        print(list.find("name", "Philosophy"))
        print('Сортування: ')
        list.sort()
        list.show()
        print("Запис у файл: ")
        list.write()
        print('Видалення по ідексу: ')
        list.insert_last(UniversityUnit("Philosophy, KNTEU, 9"))
        list.show()
        list.delete(4)
        list.show()
        print('Видалення по значенню: ')
        list.delete_by_value(UniversityUnit('name1, CHNU, 111'))
        print('Видалення по всіх значенню: ')
        list.delete_all_by_value(UniversityUnit("Philosophy, KNTEU, 9"))
        list.show()
        list.clear()
        print("Кількість елементів: " + str(list.count()))
        print('Загрузити з файла: ')
        list.get_from_array(from_file2())
        list.show()
    else:
        break