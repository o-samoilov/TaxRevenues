## Застосування генетичного алгоритму для моделювання та оптимізації податкових надходжень

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

![alt text](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/gen_settings.png)

**Коефіцієнт** – впливає на роботу команди чи питання.

**Результат/Відповідь** – це число на яке буде зроблений перехід до наступного елементу гена, після роботи команди/питания
Робота підприємства буде виконуватись наступним чином, починаючи курсор спочатку вказує на перший елемент гену.

### Приклад гену

![alt text](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/gen_example.png)

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

![alt text](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/mutation.png)

**Фітнес-функція** підприємства:

![alt text](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/fitness_function.png)

##Початкові умови
Задамо початкові умови до кожного об’єкту. Для податкової задано функцію tax(податки), як 45,2% від прибутку, 
ці дані ми взяли з Doing Business: “середня українська компанія повинна віддавати на податки та збори 45,2% від свого прибутку».

«Оптимізація податків» розрахована з точки зору, що існують в Україні компанії, які «оптимізують податки» за допомогою ФОП 3-ої групи, 
який сплачує 5% до бюджету та 1 у. о. на обслуговування даної «оптимізації».

Кожен день з підприємства будемо знімати 100 у.о., а максимальний час життя підприємства 50 днів. Підприємство помре коли закінчаться гроші чи пройде час його життя.

*Умовний день у системі триває 2 секунди

![alt text](https://raw.githubusercontent.com/a-samoylov/TaxRevenues/master/docs/img/start_settings.png)

**Основні характеристики системи**: у підприємства спочатку **1000 у.о.** на балансі, за **100 у.о.** підприємство може зробити продукт 
і за **150 у.о.** продати на біржі.

## Програмний продукт


## Authors

Alexander Samoylov
> [LinkedIn](https://www.linkedin.com/in/alexander-samoylov/)

> [GitHub](https://github.com/a-samoylov)