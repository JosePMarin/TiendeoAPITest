                                                          API REST
    
Para el test de la API de la web: https://www.themoviedb.org. Usaremos:
    
|RestSharp | Para realizar las llamadas de API                         |
|:---      |    :---:                                                  |     
|NUnit     | Como framework para los tests unitarios                   |
|SpecFlow  | Framework para la generación de test cases BDD (cucumber) |
    
Por lo recuestado en el ejercicio se van a ejecutar las llamadas GET y POST para los endpoints: 

https://developers.themoviedb.org/3/movies/get-top-rated-movies Calls a este endpoint con status code esperados 200 y 401 (200 corresponde a un Get call exitoso, mientras que 401 es un bad request). Asi que el escenario elegido para este endpoint será un caso positivo y otro negativo de un GET call.

https://developers.themoviedb.org/3/movies/rate-movie Para este endpoint cubriremos los escenarios positivos y negativos con status code 201 y 401 (201 corresponde a elemento creado, lo cuál suele tener relación directa con un POST call existoso y 401, por el contrario, define un bad request). Así que el escenario elegido para este endpoint será un caso positivo y otro negativo de un POST call. 

                                                    Estructura de test API
                                                    
Test1: Get requests

|PositiveScenario: GetCall con respuesta 200|
|           :---:                           |
|NegativeScenario: GetCall con respuesta 400|
|NegativeScenario: GetCall con respuesta 401| 

Test2: Post requests

|PositiveScenario: PostCall con respuesta 200|
|           :---:                            |
|NegativeScenario: PostCall con respuesta 400|
|NegativeScenario: PostCall con respuesta 401| 

Nota: Habiendo hecho un test exploratorio de la API con PostMan, he podido descubrir que la API no controla headers (antibot) ni autentificación, con lo que la respuesta 401 (unauthorized) no está implementada en la API. Con PostMan sin embargo he conseguido realizar un Bad Request (400). 
(*Mirando en la descripción de la API en la web de la misma, el ejemplo de RequestBody no se relaciona a lo recibido, lo cual debería de ser testeado aunque creo que queda fuera del scope del ejercicio). 
