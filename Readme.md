# Застосування генетичного алгоритму для моделювання та оптимізації податкових надходжень

## Постановка задачі

Маємо модель, яка складається с трьох класів об’єктів: **податкова**, **біржа**, **підприємство**.

<table>
	<thead>
		<td>
			<b>Об’єкт</b>
		</td>
		<td>
			<b>Характеристики</b>
		</td>
	</thead>
	<tr>
		<td>
            <p align="center">Подактова</p>
			<img width="100" alt="render-one" src="https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/tax_office_ico.png">
		</td>
		<td>
			<img width="400" alt="render-one" src="https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/tax_office_settings.png">
		</td>
	</tr>
	<tr>
		<td>
            <p align="center">Біржа</p>
			<img width="100" alt="render-one" src="https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/exchange_ico.png">
		</td>
		<td>
			<img width="400" alt="render-one" src="https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/exchange_settings.png">
		</td>
	</tr>
	<tr>
		<td>
            <p align="center">Підприємство</p>
			<img width="100" alt="render-one" src="https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/manufacture_ico.png">
		</td>
		<td>
			<img width="400" alt="render-one" src="https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/manufacture_settings.png">
		</td>
	</tr>
</table>

## Хромосома підприємства
Хромосома підприємства буде складатись з одного гену. Ген буде масивом з 64 команд чи питань.

![gen_settings](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/gen_settings.png)

**Коефіцієнт** – впливає на роботу команди чи питання.

**Результат/Відповідь** – це число на яке буде зроблений перехід до наступного елементу гена, після роботи команди/питания.

### Приклад гену

![gen_example](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/gen_example.png)

Розглянемо хромосому, яка складається з генів g1…g64. Припустимо, що ген g1 являє собою питанням №1 (Отримати розмір податків). 
Підприємство бере продукт з початковими умовами собівартості і ціни його на біржі, та розраховує за допомогою податкової кількість податків, 
які потрібно заплатити, згідно з цього отримує відповідь у вигляді числа від 1 до 3, де 1 – мало, 2 – середнє, 3 – великі. 
Згідно з числа відповіді на питання відбувається перехід до наступного елементу гена. Наприклад відповідь 2. Далі виконуємо команду g3.

## Початкова популяція, відбір та мутація.
Спочатку випадковим чином створюється деяка початкова популяція. Запускається моделювання і після того, як загинуть усі особини робимо відбір.
Відбір, найкращі підприємства ми будемо обирати за фітнес функцією. Після відбору найкращих особин, 
вони створять N нащадків і з вірогідністю 20% станеться мутація хромосоми.

**Мутація**

Під час моделювання підприємство буде виглядати, як на рисунку, над ним будуть дві сфери, колір верхньої – відображає поточну хромосому, 
а нижньої нащадка, як ми бачимо після мутації особина отримала новий рожевий колір поточної хромосоми (мутованої), 
а хромосома пращуру  зелений опустився вниз. Це дозволяє ілюструвати “сімейства” особин однієї хромосоми і від кого вони створенні.

![mutation](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/mutation.png)

**Фітнес-функція** підприємства:

![fitness_function](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/fitness_function.png)

## Початкові умови
Задамо початкові умови до кожного об’єкту. Для податкової задано функцію tax(податки), як 45,2% від прибутку, 
ці дані ми взяли з Doing Business: “середня українська компанія повинна віддавати на податки та збори 45,2% від свого прибутку».

«Оптимізація податків» розрахована з точки зору, що існують в Україні компанії, які «оптимізують податки» за допомогою ФОП 3-ої групи, 
який сплачує 5% до бюджету та 1 у. о. на обслуговування даної «оптимізації».

Кожен день з підприємства будемо знімати 100 у.о., а максимальний час життя підприємства 50 днів. Підприємство помре коли закінчаться гроші чи пройде час його життя.

*Умовний день у системі триває 2 секунди

![start_settings](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/start_settings.png)

**Основні характеристики системи**: у підприємства спочатку **1000 у.о.** на балансі, за **100 у.о.** підприємство може зробити продукт 
і за **150 у.о.** продати на біржі.

## Програмний продукт

Натисни щоб подивитись:

[![video](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/program1.png)](https://drive.google.com/file/d/1mcGShiUHu7x3jc8YVN4HfiBcoV36qQFd/view?usp=sharing)

Інші відео:

[Відео 1](https://drive.google.com/file/d/1V54f3UQo3sX6qBrdOREmYxGfQxApuLUD/view?usp=sharing)

[Відео 2](https://drive.google.com/file/d/1X_eXqv1yHdXIrUgi_8JxCvY7zSPxDg4R/view?usp=sharing)

[Відео 3](https://drive.google.com/file/d/1X4CwRte5BVa8wbM5nsktipx2FYyiEe2D/view?usp=sharing)

## Результати

<table>
	<thead>
		<td>
			<div>
                <p>
                    Виявилось для підприємства оптимально зменшувати собівартість до ~97 у.о. оптимальний час створення продукції став  ~0.46 с.
                </p>
                <p>
                    Зменшувати собівартість до мінімальної позначки не є оптимальною стратегією, спочатку підприємства дуже сильно зменшували собівартість, 
                    це видно на графіку "Середня собівартість продукції", але оскільки життя підприємства обмежене 50 днями, вони не встигали заробити достатньо грошей щоб бути конкурентоспроможними.
                </p>
                <p>
                    На графіку "Середній час створення продукту" видно як алгоритм завдяки мутаціям шукав оптимальний час створення продукції, спочатку зменшував його, потім перестав, але згодом він визначився ~0.46.
                </p>
            </div>
		</td>
		<td>
			<img width="900" alt="render-one" src="https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/programm2.png">
		</td>
	</thead>
</table>

![graph1](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/graphs/graph1.png)

![graph2](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/graphs/graph2.png)

Графік "Середня суми на рахунках підприємства", схож на ломану, оскільки алгоритм чекає поки усі особини загинуть і 
починає нову ітерацію. Видно зв’язок з попередніми графіками, спочатку до 1000 дня алгоритм шукав як виживати взагалі, 
а згодом зміни балансу зв’язані з покращенням характеристик підприємств.

![graph3](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/graphs/graph3.png)

На графіках податкових надходжень ми бачимо, що після 1000 дня майже всі підприємства «оптимізували податки», 
та кількість недоотриманих грошей податковою просто колосальна. Це означає, що навіть маючи високі податки, та слабку систему нагляду, 
обов’язково багато підприємств буде платити менше, це ми бачимо і в реаліях України. Але, що буде якщо збільшити штрафи і наглядову систему, є
то зменшується ВВП, оскільки підприємства не можуть витрачати достатньо грошей на свої покращення і це фатально для економіки  країн, що розвиваються.

![graph4](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/graphs/graph4.png)
![graph5](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/graphs/graph5.png)

![description](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/graphs/description.png)

## Висновки

З результатів роботи видно, що підприємства оптимізували сплату податків до бюджету та знайшли найоптимальніші критерії для роботи в даній системі. 
ержава недоотримала багато грошей, а підприємствам потрібно було платити багато штрафів за таку роботу. Один з варіантів розв’язку проблеми зниження податкового 
тиску передусім важливо у країнах з перехідною економікою, якою і є Україна на даний монет, оскільки прозора система з низькими податками принесе до бюджету 
набагато більше коштів (наприклад, в нашій моделі ми не рахували, грошову масу податків, які взагалі не заплатили) і буде сприяти розвитку ВВП і всіх секторів економіки, 
що є найважливішим для збагачення країни.

## Authors

Alexander Samoylov
> [LinkedIn](https://www.linkedin.com/in/alexander-samoylov/)

> [GitHub](https://github.com/a-samoylov)