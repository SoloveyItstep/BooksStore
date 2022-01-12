							Books store

Структура
-	Главная

-	Акции
•	Список акций
•	Страница акции

-	Страница товара
•	Страница категорий товаров
•	Описание (быстрый заказ)
•	Страница авторов
•	Страница автора
•	Страница поиска

-	Корзина
•	Оформление покупки товаров

-	Страницы пользователя
•	Регистрация
•	Авторизация
•	Личный кабинет
•	Редактирование данных
•	Восстановление пароля
•	Повторная отправка электронного письма для подтверждения электронной почты
•	Страница истории заказов
•	Избранные товары

-   Административная панель
•	Страница пользователей
•	Страница пользователя
•	Страница заказа
•	Страница заказов
•	Страница товаров
•	Страница редактирования товара
•	Страница создания товаров
•	Страница списка авторов
•	Страница редактирования автора
•	Страница создания автора

-   Информационные страницы
•	О нас
•	Оплата и доставка
•	Контакты

Языки
Украинский, Английский. По умолчанию установлен Украинский язык. Должны быть возможность расширять языки. Выбранный язык необходимо сохранять в памяти браузера. Если данных по выбранному языку не нашлось, тогда выбор должен происходить по следующим предпочтениям:
- Украинский
- Английский

Детализация структуры
	Хедер и Футер:
	Все страницы, за исключением административных, будут содержать хедер и футер.
	Хедер содержит:
- логотип с переходом на главную страницу
- информационные ссылки
	* Про нас
	* Доставка
	* Оплата
	* переключение языка
- ссылки на основные категории (ссылки переадресовывает на страницу каталога товаров с соответствующей настройкой фильтра, выбранного тип книг):
	* Е-Книги
	* Аудио книги
	* Печатные книги
- Персональные ссылки:
	* Избранное. В случаи не проведенной авторизации, при нажатии на кнопку выполнится переадресация на страницу авторизации. В противном случаи осуществляется переход на страницу избранных товаров.
  * Корзина. При нажатии открывается всплывающее окно с перечнем выбранных товаров и кнопкой для перехода на страницу оформления заказа. В случаи отсутствия товаров в корзине – кнопка перехода на страницу оформления заказов отсутствует.
  * Личный кабинет. В случаи не проведенной авторизации, при нажатии на кнопку выполнится переадресация на страницу авторизации. В противном случаи осуществляется переход на страницу Личный кабинет.
  * Поиск товара. Поиск осуществляется по названиям книг и ФИО авторов. Поиск работает по принципу быстрого поиска и отображает первые семь результатов поиска. При нажатии на кнопку поиска происходит переход на страницу поиска. Поиск не должен происходить, если не было введено никаких символов.
Хедер при уменьшении до размеров планшета или телефона минимизируется до логотипа и гамбургер меню. Все ссылки на страницы и корзину переносятся в боковое меню.
Внизу хедера присутствует кнопка для просмотра каталога всех категорий книг. При нажатии на определенную категорию книг осуществляется переход на страницу списка книг выбранной категории.
	Футер содержит:
Футер содержит ссылки на товары по основным категориям книг.

		Главная страница:
- Кнопка перехода на каталог товаров
- Акции. Блок акций в формате слайдера с переходом на страницу акции.
- Новинки. Выбирается последние добавленные 8-10 книг. Количество необходимо подбирать по высоте картинок для отображения для равномерного отображения. В конце присутствует кнопка для перехода на страницу товаров.
- Про нас. Базовая информация о нашей страсти к чтению книг. В блоке присутствует кнопка для перехода на страницу «О нас».

Страница списка акций:
	Страница акций содержит в себе список акций с кратким ее содержимым и ссылками на страницы их описаний. Каждая акция оформлена равномерными блоками. Каждый блок содержит фотографию, заглавие и краткое описание, ссылку на страницу акции.
	Станица предусматривает отображение списка акций с прошедшими датами. Для таких акций должна быть предусмотрена функция уведомления пользователя об завершении акции. Список должен отображаться с предусмотренной пагинацией по восемь акций на странице.

		Страница акции:
Страница акции содержит фотографию или баннер акции, заглавие, даты начала и окончания акции, полное описание. Страница оформлена шаблоном с возможностью отображения текста с помощью кода HTML для выделения текста жирным, наклонным шрифтами или подобными.

		Страница категорий товаров:
Страница товаров содержит три популярных (рекомендуемых) группы товаров для покупателя. Каждая группа имеет заглавие и десять-пятнадцать книг из группы. В конце списка книг присутствует кнопка «больше книг» для просмотра всех книг данной группы.
На странице должна присутствовать возможность отфильтровывать и сортировать товары. Фильтрация должна производиться по следующим категориям:
•	Тип книги
•	Автор
•	Переплет
•	Цена
В фильтрации должна присутствовать кнопка удалять выбранный фильтр или очистить все фильтра.
Сортировка должна производиться по следующим категориям:
•	Названию (по возрастанию ли по убыванию)
•	Цене (по возрастанию ли по убыванию)
Если на странице выбрана одна из категорий, то в таком случае отображаются все книги по выбранной категории. Если выбрана категория «Все категории», тогда отображаются книги без фильтрации по категориям.
Страница имеет пагинацию по страницам категорий. На каждой странице присутствуют три категории по их популярности.

		Страница списка товаров:
Страница списка товаров отображает список книг из выбранной категории книг. Книги отображаются в формате картинок. В случае отсутствия картинки подставляется шаблонная картинка. При наведении на картинку она перекрывается окном поверх картинки с базовой информацией и кнопкой перехода на страницу товара.
При наведении на картинку отображается следующая информация:
•	Автор
•	Название книги
•	Цена

		Страница товара:
Страница товара содержит:
•	Картинки (обложка) книги
•	Заглавие
•	Код товара
•	Наличие товара
•	Автор
•	Издательство
•	Язык
•	Тип
•	Переплет
•	Формат
•	Количество страниц
•	Год выпуска
•	Цена
•	Описание
•	Об авторе
•	Отзывы и рейтинг
o	Автор отзыва
o	Рейтинг до 5 звезд
o	Дата отзыва
o	Текст отзыва до 350 символов (отображать первые три строки а возможность отобразить/скрыть отзыв)

	Страница должна содержать вышеперечисленные данные о книге, а также возможность совершить быстрый заказ через внесение номера телефона и имени покупателя.
	В случае отсутствия книг система не должна позволять сделать заказ товара.

Страница авторов:
	Страница авторов содержит список авторов по их именам и количество книг в магазине, зарегистрированных на них.

Страница автора:
Страница автора содержит:
•	Фотографии автора
•	ФИО автора

Страница оформления заказа:
Страница оформления заказа должна предполагать собой четыре блока оформления заказа:
1)	Просмотр списка товаров:
  a.	Товары отображаются малыми блоками с краткой информацией в формате списка. Должна быть предусмотрена возможность перехода на страницу описания товара.
  b.	Подведена общая сумма выбранных товаров и их количество.
  c.	Возможность удаления товара или редактирование количества товаров. В случае удаления последнего товара должна производиться переадресация на страницу корзины.
2)	Пользовательские данные о получателе. Данные должны подставляться из указанных пользователем как данные по умолчанию (см. Личный кабинет). Следующие поля должны быть отображены пользователю для заполнения/редактирования/проверки
  a.	Имя получателя (обязательное поле, не меньше двух букв)
  b.	Фамилия получателя (обязательное поле, не меньше двух букв)
  c.	Номер телефона получателя (обязательное поле) (валидация)
  d.	Электронная почта (валидация)
3)	Доставка. В блоке доставки должны быть реализованы следующие пункты:
  a.	Самовывоз (отображать адрес магазина)
  b.	Нова Пошта. Интеграция с Нова Пошта API.
  c.	Курьерская доставки по Киеву. Поля для заполнения: улица, дом (текст с информацией о том, что доставка осуществляется только до подъезда).
4)	Оплата. Оплата по следующим критериям:
  a.	При получении
  b.	Оплата на карту
  c.	LiqPay
При выборе полной оплаты и одной из способов доставки (Нова Пошта, Курьером по Киеву) выдавать сообщение о необходимости иметь при себе документ удостоверяющем личность для указанного получателя.
	Все блоки являются обязательными для заполнения. На полях для ввода должна быть реализована валидация полей и не пропускать далее.
	Если пользователь не является авторизированным, в таком случае данные необходимо заполнять пользователю вручную. Перед там как провести оформление заказа дать пользователю возможность создать аккаунт. В случае выбора аккаунта нужно предложить пользователю создать аккаунт. Если пользователь соглашается на создание аккаунта, в таком случае необходимо:
•	Сохранить данные об оформлении заказа во временном хранилище (браузере)
•	Создать аккаунт
•	Создать заказ
•	Показать пользователю уведомление об успешном оформлении заказа
•	Переадресовать на страницу списка товаров после закрытия окна уведомления успешного оформления заказа.

Страницы пользователя и Административные страницы:
На страницах пользователя и административных страницах, за исключением страниц Регистрации и Авторизации, должны допускаться только зарегистрированные пользователи.
Для доступа на пользовательские страницы в аккаунте должна присутствовать роль «User», а для административных страниц – «Admin».
	Страница регистрации:
	Поля для заполнения:
•	Имя (обязательное, не меньше двух букв, до пятнадцати символов, запрет всех знаков, за исключением тире)
•	Фамилия (обязательное, не меньше двух букв, до тридцати символов, запрет всех знаков, за исключением тире)
•	Отчество (не обязательное или не меньше двух букв, до тридцати символов, запрет всех знаков, за исключением тире)
•	Электронная почта (обязательное, валидация) (двухфакторная аутентификация)
•	Номер телефона (обязательное, валидация)
•	Пароль (одна заглавная, одна цифра, один символ, одна строчная буква, минимум шесть символов, максимум шестнадцать символов)
•	Повторение пароля (точное совпадение с Паролем)
•	Дата рождения (опциональное поле)
После проведения регистрации делать переадресацию на главную страницу. После подтверждения пользователем электронной почты переадресовывать на страницу профиля.
Пользователь может перейти на страницу регистрации только если не был совершен вход в аккаунт. В противном случае пользователь должен быть уведомлен об необходимости выйти из текущего аккаунта и повторить переход на страницу регистрации.
Каждый аккаунт должен быть уникален для всех электронных адресов и номеров телефонов. При попытке ввода существующих данных необходимо уведомить пользователя об существующем в системе электронной почте или номере телефона и предложить восстановить пароль.

Страница авторизации:
Авторизация производится по следующим полям:
- адрес электронной почты
- пароль
	Оба поля являются обязательными для заполнения. При вводе неверных или не существующих данных необходимо уведомить об этом пользователя и стереть все поля. Страница авторизации должна отображаться как всплывающее окно (при нажатии на ссылочные кнопки) или как полноценная страница (при переходе по адресу или при переадресации).
	При попытке входа в аккаунт без подтвержденной электронной почты необходимо переадресовывать на страницу повторной отправки письма для подтверждения электронной почты.

Страница Личный кабинет:
В личном кабинете отображается следующая информация:
  •	ФИО
  •	Номер телефона
  •	Электронная почта
  •	Дата рождения
  •	Список получателей с возможностью выбора получателя по умолчанию. В случае наличия только одного получателя выбор сделан автоматически, и смена получателя по умолчанию не позволяется. Отображение должно производиться с помощью выпадающего списка. Должна присутствовать ссылка на страницу редактирования профиля.
  •	Адреса доставки. Адреса аналогично списку получателей должна отображаться с помощью выпадающего списка.
  •	Краткий список последних заказов. Должна присутствовать ссылка на переход к списку заказов.

Страница редактирования персональных данных:
Данные для редактирования/дополнения:
  •	Имя. Обязательно для заполнения. От двух до пятнадцати символов. Запрет всех знаков, за исключением тире.
  •	Фамилия. Обязательно для заполнения. От двух до тридцати символов. Запрет всех знаков, за исключением тире.
  •	Отчество. Не обязательно для заполнения или от двух до тридцати символов. Запрет всех знаков, за исключением тире.
  •	Номер телефона. Обязательно для заполнения. Валидация
  •	Электронная почта. Обязательно для заполнения. Валидация.
  •	Список получателей. Берем из ФИО аккаунта в случае отсутствия.
  •	Список адресов. Обязателен хотя бы один адрес. В адрес входит: Область, Город или поселок, Улица, Номер дома. Все поля обязательны для заполнения.
  •	Пароль. Для редактирования пароля необходимо ввести свой старый пароль, новый пароль и повторно новый пароль. Пароль валидируется соответственно паролю на странице регистрации.
  •	Дата рождения. Валидация даты. Не младше пяти лет. Поле опциональное.

Страница восстановления пароля:
На странице присутствует только поле электронной почты, и кнопка отправить. В случае отсутствия электронной почты, пользователю необходимо об этом сообщить. При успешной отправке необходимо сообщить пользователю об необходимости проверит электронную почту. Так же при успешной отправке не нужно стирать данные из поля электронной почты, а дать возможность пользователю повторно отправить письмо для восстановления пароля. После первой отправки необходимо заменить текст кнопки с «отправить» на «отправить повторно».

Страница повторной отправки электронного письма для подтверждения электронной почты:
Страница подобна странице восстановления пароля за исключением заглавия и текста уведомлений

Страница истории заказов:
Страница истории заказов отображается как сжатые блоки с возможностью развернуть подробную информацию. 
В краткой информации присутствует номер заказа, количество товаров, дака заказа, статус заказа.
В развернутой информации присутствуют номер заказа, количество товаров, дака заказа, статус заказа, список товаров з заказе. В каждом элементе товара должны присутствовать название, цена (которую уплатил покупатель), картинка (главная), возможность перейти на страницу товара.

Страница избранных товаров:
Страница имеет список выбранных товаров пользователем. Список отображается как каталог товаров на странице каталога товаров. Исключение на этой странице является возможность удаления товара из списка избранного.

Административные страницы:
Для административных страниц должен быть реализован собственных хедер с навигационной панелью для следующих страниц:
  •	Страница пользователей
  •	Страница заказов
  •	Страница товаров
  •	Главная страница
Страница пользователей:
Страница пользователей отображает список зарегистрированных пользователей малыми блоками. В каждый блок входит:
  •	ФИО пользователя
  •	Номер телефона
  •	Электронная почта
По полям пользователей должна быть возможность делать поиск. При нажатии на пользователя необходимо делать переход на страницу пользователя
Страница пользователя:
Страница пользователя содержит следующие данные:
  •	ФИО
  •	Номер телефона
  •	Электронная почта
  •	Дата регистрации
  •	Дата рождения
  •	Адреса доставки
  •	Получатели
  •	Переход на список заказов пользователя
  •	Статус пользователя
  •	Удаление пользователя (нужно подтверждение)
  •	Редактирование данных
  •	Отправка письма не восстановление пароля (заблокировано в случае отсутствия электронной почты)
  •	Блокировка
  •	Отзывы и рейтинги (отображаются малыми блоками)
    o	Дата совершения отзыва
    o	Товар (название, код) (ссылка перехода на страницу товара магазина)
    o	Текст отзыва
    o	Наличие товара среди покупок пользователем
    o	Блокировка отзыва

Страница заказа:
	Страница заказа содержит полную информацию о заказе:
  •	Список заказанных товаров
    o	Название
    o	Код товара
    o	Наличие товара
    o	Автор
    o	Издательство
    o	Язык
    o	Тип
    o	Переплет
    o	Формат
    o	Количество страниц
    o	Год выпуска
    o	Цена, по которой был оформлен товар
    o	Актуальная цена
  •	Покупатель
    o	ФИО пользователя (ссылка на страницу пользователя)
    o	ФИО получателя
    o	Номер телефона
    o	Электронная почта
  •	Тип оплаты
  •	Статус оплаты
  •	Список этапов заказа (от последнего до первого)
    o	Статус
    o	Дата
  •	Дата заказа

Страница списка заказов:
	Страница списка заказов содержит следующую информацию отображаемыми малыми блоками:
  •	Номер заказа (ссылка на страницу заказа)
  •	Количество товаров в заказе
  •	ФИО получателя (ссылка на страницу пользователя)
  •	ФИО пользователя (ссылка на страницу пользователя)
  •	Цена заказа
  •	Статус заказа
  •	Дата заказа
Заказы отображаются списком с пагинацией до 20 заказов в списке. На странице присутствует поиск и фильтр. Фильтр отфильтровывает по следующим полям:
  •	Дата заказа
  •	Статус заказа
  •	Диапазон цены заказа
  •	Количество товаров в заказе
Поиск осуществляется по всем полям присутствующим на странице списка заказов
Отображение осуществляется в отсортированном виде по дате оформления от последнего до первого.
На странице присутствует сортировка по следующим значениям:
  •	Дата заказа
  •	Дата изменения статуса заказа


Страница списка товаров:

Список товаров отображается блоками для быстрого поиска товара со следующими данными:
•	Код товара
•	Название книги (ссылка перехода на страницу редактирования товара)
•	Автор
•	Тип
•	Переплет
•	Цена
•	Наличие товара
•	Язык
•	Статус товара в магазине (активен, снят)
Страница содержит поиск по всем полям на странице. 
Страница содержит фильтр по следующим полям:
•	Тип
•	Диапазон цены
•	Наличие товара
•	Язык
•	Статус товара в магазине (активен, снят)
На странице присутствует сортировка по следующим полям:
•	Цена
•	Название
•	Статус товара в магазине (активен, снят)
По умолчанию отображение товара осуществляется в отсортированном виде по статусу товара в магазине (активен, снят)
На странице присутствует кнопка для перехода на страницу создания нового товара.
Страница редактирования товара:
Страница содержит список следующих полей, которые не редактируются:
•	Номер товара
•	Рейтинг
•	Наличие товара
•	Статус товара в магазине (активен, снят)

Редактируемые поля на странице товара:
•	Картинки (добавление, удаление, порядок отображения)
•	Заглавие (обязательное поле)
•	Количество товара (обязательное поле)
•	Автор (обязательное поле)
•	Издательство
•	Язык (обязательное поле)
•	Тип (обязательное поле)
•	Переплет (обязательное поле)
•	Формат
•	Количество страниц (обязательное поле)
•	Год выпуска
•	Цена (обязательное поле)
•	Описание
•	Статус товара в магазине (активен, снят)
Все поля имеют вид не редактируемого поля. Для редактирования поля необходимо нажать на кнопку редактирования.
Все поля, имеющие текстовое редактируемое значение дублируются для каждого имеющегося языка в системе.
Авторы выбираются из списка существующих. В случае отсутствия автора списка существует возможность создать нового автора перешедши на страницу создания автора. После создания автора система должна переадресовывать на страницу создания/редактирования товара с предварительно заполненными полями.


Страница добавления товара:

Страница добавления товара имеет одинаковую структуру как страница для редактирования товара.

Страница списка авторов:
	Страница списка авторов отображается малыми блоками. Каждый блок содержит следующие данные:
•	ФИО автора (ссылка на страницу редактирования данных автора)
Страница содержит поиск для поиска авторов по имени.
Страница содержит сортировку по Фамилии автора
Список отображается по 30 значений на странице и имеет пагинацию.
На странице присутствует кнопка для добавления нового автора.

Страница редактирования/добавления/удаления авторов:
Страница содержит следующие данные:
•	ФИО (обязательное поле)
•	Дата рождения
•	Биография
•	Список книг автора в магазине (с возможностью перехода на книгу)
Все поля редактируются. На странице присутствует кнопка удаления автора. Удалить возможно лишь того автора, на котором не зарегистрированы книги.

Страница О нас:
Содержит информацию о магазине и ее работниках, о целях и вдохновении тех, кто в ней работает.

Страница платы и доставки:
Страница содержит информацию о вариантах оплаты и вариантах доставки товара

Страница контактов:
Страница контактов содержит контакты для связи с работниками магазина.