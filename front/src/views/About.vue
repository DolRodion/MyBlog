<template>
  <div v-if="getData != null" class="aboutCheck">
    <h2>{{ getData.Name }}</h2>

    <div v-if="getData.IsCheckedVideoUrl"><iframe width="750" height="450" :src="getData.ImageUrl" title="YouTube video player"
            frameborder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
            allowfullscreen></iframe>
        </div>

        <div v-else><img :src="getData.ImageUrl" /></div>

    <ul class="aboutUl" style="padding: 0;">
      <li><router-link v-for="tag in getData.Tags" class="buttonStyle2" :to="getCheckTagName(tag)">#{{tag}}</router-link></li>
    </ul>
  
     <span class = "spanGray">Автор: </span> <span >{{ getData.CheckAuthor }}</span>
    <br>
    <p class = "textCheck">{{ getData.Text }}</p>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { CheckDataShortModel, HomeService } from '@/AxiosSetup/service';


@Component({
  components: {
  },
})
export default class About extends Vue {
 @Prop() id!: number | string;
 private data?: CheckDataShortModel | null = null;

  async created() 
  {
    try {
      this.data = await HomeService.GetCheckById(this.id as number);
    }
    catch (e) {
      alert("Произошла ошибка при получении записи.");
    }
  }

  public getCheckTagName(tagName: any) {
    return "/home/getCheckByTagName/" + tagName;
  }

  get getData()
  {
    return this.data;
  }
}

</script>

<style> 
.aboutCheck{
  width: 70%;
  max-width: 900px;
}
.aboutCheck img {
  width: 100%;
  max-width: 900px;
}

.textCheck {
  text-indent: 45px;
  line-height: 2;
}
h2 {
  text-align: center;
}

span{
  margin-top:20px;
}
.spanGray {
  color: gray;
}

.aboutUl li {
  display: inline-block;
}

.aboutUl li a{
  display: block;
}
</style>