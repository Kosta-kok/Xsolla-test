# Протестировать Xsolla Promotions API
http://developers.xsolla.com/api.html#promotions

Задачи
Изучить документацию и написать тест план
Выбрать инструмент для написания тестов. Выбор нужно обосновать.
Написать работающие тесты
Составить список ошибок, замечаний, пожеланий к API
* Все команды тестировать не обязательно. 100% покрытие не требуется. 
В результате должен быть документ и код. 

Реквизиты для тестов: 
merchant_id: 22174;
project_id: 15861;
api_key:O8bS0aZNZbKuiONw;
payment_systems.id: 2682; 
packages: 1.

Для тестирования был выбран язык программирования C# и Framework NUnit.
 У меня уже есть уже опыт написания кода на C#, поэтому был выбран именно C#.
 т.к. нет опыта написания автоматизированных тестов был выбран первый попавшийся Framework NUnit.
 
 Список замечаний к API:
 1. В документации нет описани сущности digital_contents
 2. В документации есть описание поля rewards.Item.Bonus.amount, но по факту в API его нет, зато есть quantity.
 3. Один из запросов вернул ошибку, где было сказано проверить структуру по ссылке https://developers.xsolla.com/ru/api_v2.html#set-the-subject, но переход к нужному объекту не был осуществлён.
 4. При отправке запроса SetTheSubject {"purchase":false,"items":null,"packages":null,"subscriptions":null,"digital_contents":[{"id":1,"localized_name":"test12","drm":[{"id":1,"name":"Steam"},{"id":2,"name":"Playstation"}]}]}
пришла ошибка
{ "http_status_code": 422, "message": "digital_content_does_not_belong_to_project", "extended_message": { "global_errors": [], "property_errors": { "digital_content": [ "digital_content_does_not_belong_to_project" ] } }, "request_id": "cd3b1db" }
Текст ошибки не должен быть идентификатором.
Аналогично пришла ошибка "digital_content_not_existing_id" при задании "..."digital_contents":[{"id":15861..."
В результате не удалось сформировать правильный запрос digital_contents.
5. При удалении акции удаляются даже те, у которых enabled = true, в ответе запроса DeletePromotion нет никаких ошибок. 
