<template>
  <div class="home">
    <h1>Тема дизайна «Блогер»</h1>
    <p class="titleP">Первая специализированная адаптивная тема дизайна на платформе webasyst для создания вашего
      собственного блога!</p>
    <ul class="mainUl">
      <li v-for="item in getData">
        
        <h3 class="removeCheck"><a v-if="showCross" class="removeCheck" v-on:click="GetId(item.Id)">&#10060;</a>{{ item.Name }}</h3>
        <ul class="attrCheck">
          <li>
            <img src="@/assets/1.png" class="imgBlog">
            <p>{{ item.CreateDate }}</p>
          </li>
          <li>
            <img src="@/assets/2.png" class="imgBlog">
            <p>{{ item.CheckAuthor }}</p>
          </li>
          <li>
            <img src="@/assets/3.png" class="imgBlog">
            <p v-if="item.CommentCount == 0">Нет комментариев</p>
            <p v-else>{{ item.CommentCount }} комментариев</p>
          </li>
        </ul>

        <div v-if="item.IsCheckedVideoUrl"><iframe width="750" height="450" :src="item.ImageUrl" title="YouTube video player"
            frameborder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
            allowfullscreen></iframe>
        </div>

        <div v-else><img class="imageBlock" :src="item.ImageUrl" /></div>
        <br>
        <p class="classP">{{ item.Text }}</p><br>
        <router-link :to="getCheckId(item.Id)" class="buttonStyle">Читать подробнее &#10141;</router-link>
        <br>
        <br>
          <router-link v-for="tag in item.Tags" class="buttonStyle2" :to="getCheckTagName(tag)">#{{ tag }}</router-link>
      </li>
    </ul>

  </div>
</template>



<script lang="ts">
import { CheckDataModel, HomeService,AdminService } from '@/AxiosSetup/service';
import { Component, Vue } from 'vue-property-decorator';


@Component({
  components: {
  },
})
export default class Home extends Vue {
  private data: CheckDataModel[] = [];
  public showCross: boolean = false;

  async created() {
    this.showCross = localStorage.getItem('password') == "condominium";
    this.data = await HomeService.GetAllCheck();
  }

  public getCheckId(id: any) {
    return "/about/info/" + id;
  }

  public getCheckTagName(tagName: any) {
    return "/home/getCheckByTagName/" + tagName;
  }

  public async GetId(id: number) {
    try{
      const result = await AdminService.RemoveCheckById(id);

      if (result){
        alert("Запись успешно удалена");
        location.reload();
      }
    }
    catch(e)
    {
      alert("Идентификатор не найден");
    }
  }
  
  get getData() {
    return this.data;
  }
}
</script>

<style>

.home {
  width: 70%;
  max-width: 900px;
}

.mainUl {
  padding: 0px;
}

.mainUl ul {
  padding: 0px;
}

.mainUl h3 {
  margin-top: 60px;
}

.mainUl li {
  list-style-type: none;
  display: inline-block;
  margin: 0px 10px;
}

.mainUl li:first-child {
  margin: 0px;
}

.mainUl li a {
  text-decoration: none;
}

.mainUl img {
  margin-right: 5px;
  width: 760px;
}

.mainUl button {
  border: 2px solid #f0f4f7;
  font-size: 16px;
}

.mainUl .imgBlog {
  width: 13px;
  height: 13px;
}

.buttonStyle {
  border: 1px solid #0db3e3 !important;
  font-size: 20px;
  color: #0db3e3;
  background-color: white;
  padding: 10px 30px;
  cursor: pointer;
}

.buttonStyle:hover {
  background-color: #0db3e3;
  color: white;
  transition: 0.5s;
}

.buttonStyle2 {
  font-size: 15px;
  color: white;
  background-color: #0f68f6;
  padding: 8px 20px;
  margin: 8px 5px;
  cursor: pointer;
  float: left;
  border-radius: 10px;
  border: 1px solid #f5f5f5 !important
}

.buttonStyle2:hover {
  color: rgb(120, 224, 120);
  transition: 0.5s;
}

.mainUl p {
  font-size: 17px;
  text-align: justify;
  color: black;
  line-height: 1.5;
  display: inline-block;
  

}

.mainP{
  margin-right: 20px;
}

.classP {
  text-indent: 45px;
}

span {
  margin-top: 10px;
  font-size: 18px;
}

.titleP {
  color: #868e96;
  font-size: 19px;

}

.attrCheck li {
  margin-left: 40px;
}

.attrCheck li:first-child {
  margin-left: 0;
}

.removeCheck{
  display: inline-block;
}
</style>