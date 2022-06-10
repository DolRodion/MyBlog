<template>
  <div>
    <ul class="leftMenu">
      <h4>МОЙ БЛОГ</h4>
      <li><router-link to="/">Главная</router-link></li>
      <li><router-link to="/home/getCheckByTagName/Путешествия">Путешествия</router-link></li>
      <li><router-link to="/home/getCheckByTagName/Планы">Планы на будущее</router-link></li>
      <li><router-link to="/home/getCheckByTagName/Работа">Сейчас в работе</router-link></li>
      <li><router-link to="/account/authorization">Вход</router-link></li>
    </ul>

    <div class="content">
      <div class="rightBlock">
        <input placeholder="Поиск по публикациям">
        <br>
        <br>
        <h4>ОБО МНЕ</h4>
        <hr>
        <a href="https://vk.com/id224187351"><img src="@/assets/Ava.jpg" class = "avatar"></a>
        <p>В этом блоке вы можете кратко рассказать о себе. При желании, вы можете загрузить вашу фотографию.</p>
        <br>
        <h4>МОИ СОЦСЕТИ</h4>
        <hr>
        <a href="https://vk.com/in_fini_ti"><img src="https://pngicon.ru/file/uploads/vk-128x128.png" alt="Значок вк" class = "socialNetWork"></a>
        <a href="https://www.instagram.com/conadar"><img src="https://pngicon.ru/file/uploads/instagram-1-128x128.png" alt="инстаграмм" class = "socialNetWork"></a>
        <a href="https://www.youtube.com/"><img src="https://pngicon.ru/file/uploads/2_44-128x128.png" alt="YouTube" class = "socialNetWork"></a>
        <br>
        <br>
        <h4>ТЕГИ</h4>
        <hr>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Путешествия">#Путешествия</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Планы">#Планы</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Спорт">#Спорт</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Отдых">#Отдых</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Юмор">#Юмор</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Отпуск">#Отпуск</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Крым">#Крым</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Бизнес">#Бизнес</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Лето2022">#Лето2022</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/IT">#IT</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/МоёАвто">#Авто</router-link>
        <router-link class="buttonrightBlock"  to="/home/getCheckByTagName/Семья">#Семья</router-link>
      </div>
      <router-view />
    </div>
    

  </div>
</template>

<script lang="ts">
import { CheckDataModel, HomeService } from '@/AxiosSetup/service';
import { Component, Vue } from 'vue-property-decorator';
import router from './router';


@Component({
  components: {
  },
})
export default class App extends Vue {

}


</script>



<style>
@import url('https://fonts.googleapis.com/css2?family=Merriweather:wght@300&family=Roboto+Slab:wght@200;300;400;800&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Merriweather:wght@300&family=Roboto+Slab:wght@200;300;400;800&display=swap');
h1,h2,h3,h4 {
  font-family: 'Merriweather', serif;
  font-family: 'Roboto Slab', serif;
}
p,a,span{
  font-family: 'Merriweather', serif;
  font-family: 'Roboto Slab', serif;
  line-height: 1.5;
  text-align: justify;
}
body {
  padding: 25px;
  background-color: #e1e6ed;
}
.leftMenu {
  float: left;
  position: fixed;
  margin: 0px;
  background-color: #f0f4f7;
  width: 200px;
  height: 100%;
}

.leftMenu li {
  list-style-type: none;
  font-size: 18px;
  padding: 0px 0px;

}
.leftMenu li:first-child {
  margin-top: 20px;
}
.leftMenu li a {
  cursor: pointer;
  text-decoration: none;
  color: black;
  margin-bottom: 20px;
  display: inline-block;
}
.content {
  margin-left: 240px;
  background-color: white;
  height: 87%;
  position: fixed;
  width:80%;
  overflow-y: scroll;
  padding: 25px 40px;
}

h1 {
  font-size: 44px;
}
h3 {
  font-size: 26px;
  color: #333;
}

.rightBlock{
  position: relative;
   float: right;
   width: 250px;
   margin-left: 35px;
}

.rightBlock input {
  padding:12px 25px;
  border: 0.5px silver black;
  width: 210px;
}
.rightBlock p{
  font-size: 16px;
  text-align: center;
  margin-left: 10px;
}
.rightBlock hr {
  width:220px;
  border: none;
  border-top:1px solid #f5f5f5;
}

.rightBlock .avatar {
  width: 200px;
  text-align: center;
  margin-left: 10px;
  border-radius: 50%;
}
.rightBlock .socialNetWork {
  width: 35px;
  height: 35px;
  padding-left: 10px;
  margin-top:10px;
}
.buttonrightBlock {
  font-size: 14px;
  color: white;
  background-color: rgb(47, 80, 172);
  padding: 10px 30px;
  cursor: pointer;
  margin: 5px;
  float: left;
  border-radius: 10px;
  padding: 7px;
  border: 1px solid #f5f5f5 !important
}
.buttonrightBlock:hover{
  color: rgb(120, 224, 120);
  transition: 0.8s;
}

</style>
