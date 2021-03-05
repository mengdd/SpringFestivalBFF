# SpringFestivalBFF

## Tasks

BFF Tasks:
* [] ShowController: CRUD
* [] VoteController: CR
* [] LotteryController: R
* [x] Call against the service
* [x] Refactor the network part: use Generic for type, use options for endpoint url, extract common logic.
* [] Homepage
* [] Validation


## Questions
* [] 为什么请求`https://localhost:5001/Show`非得是https?用http拿不到结果?
* [] 为什么service要有一个接口? service的注入方式有什么不同?
* [x] 反序列化默认是区分大小写的, service的响应中字段名是小写, 而Model中属性是大写开头, 所以反序列化不成功. 
  需要设置:
```
 var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };
```
然后传入:
```
JsonSerializer.DeserializeAsync
                <List<Show>>(responseStream, options);
```