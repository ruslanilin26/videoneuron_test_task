Инструкция по запуску:
- Запустить Docker
- В терминале перейти в директорию проекта ".../videoneuron_test_task"
- Прописать команду "docker-compose up --build"
- Для тестирования можно открыть браузер и перейти по адресу "http://localhost:8088/swagger/index.html",
  где откроется страница Swagger.

Задание:
Необходимо разработать простой api сервис для управления университетами со следующим функционалом:

Существует 3 основные сущности:

Университет:
Идентификатор
Название
Город

Группа:
Идентификатор
Название

Студент:
Идентификатор
Имя
Фамилия

Необходимо реализовать возможность создания университетов, создания групп, создания студентов. 
В каждом университете должна быть возможность создавать группы, в группы добавлять студентов из университета.
Студент может состоять в любом кол-ве университетов, а также в любом кол-ве групп в рамках любого из университетов.

Также необходимо подготовить Dockerfile для данного сервиса.

Технологии:
ASP NET Core
Entity Framework/Dapper
База данных может быть любой
Docker

Оформление результата:
Исходный код необходимо разместить на любом публичном репозитории (например, github)
