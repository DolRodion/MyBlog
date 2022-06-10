<template>
  <div>
    <v-form>
      <h1>Добавление записи</h1>
      <p>Название записи</p>
      <v-text-field v-model.trim="data.Name"> </v-text-field>
      <p>Url картинки/видео Ютуб</p>
      <input type="checkbox" class="checkbox" v-model="data.IsCheckedVideoUrl" />
      <p class="forCheckbox">Выберите если вставляете видео</p>
      <v-text-field v-model.trim="data.ImageUrl"> </v-text-field>
      <p>Описание записи</p>
      <v-text-field v-model.trim="data.Text"> </v-text-field>
      <p>Теги</p>
      <v-text-field v-model.trim="dataTag"> </v-text-field>
      <br>
      <br>
      <v-btn @click="AddCheck()" class="inputAddCheck">Добавить запись</v-btn>
    </v-form>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { FormAddCheckParams, AdminService } from '@/AxiosSetup/service';
import router from '@/router';


@Component({
  components: {
  },
})
export default class AddMyCheck extends Vue {
  public data: FormAddCheckParams = new FormAddCheckParams();
  public dataTag: string = "";

  created()
  {
    if (localStorage.getItem('password') != "condominium") {
      router.push({ path: '/' })
    }
  }


  public async AddCheck() {
    this.dataTag = this.dataTag.replace(/\s/g, '');
    this.data.Tags = this.dataTag.split(",");
    if (localStorage.getItem('password') == "condominium") {
      const result = await AdminService.AddCheck(this.data);

      if (result) {
        router.push({ path: '/' })
      }
    }
    else {router.push({ path: '/' })}

  }
}


</script>

<style>
.checkbox {
  margin: 0;
}

.forCheckbox {
  display: inline-block;
  margin: 5px 0px 5px 10px;
}

.inputAddCheck {
  width: 178px;
  border: 1px solid #0db3e3 !important;
  font-size: 1px;
  color: #0db3e3;
  background-color: white;
  padding: 5px 5px;
  cursor: pointer;
}


.inputAddCheck:hover {
  background-color: #0db3e3;
  color: white;
  transition: 0.5s;
}
</style>