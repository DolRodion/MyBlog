<template>
  <div>
    <v-form>
      <p>Email</p>
      <v-text-field v-model.trim="data.Email"> </v-text-field>
      <p>Password</p>
      <v-text-field v-model.trim="data.Password"> </v-text-field>
      <br>
      <br>
      <v-btn @click="Authorization()" value="Вход" class ="inputRegistration">Вход</v-btn>
    </v-form>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { FormAuthorizationParam, AccountService } from '@/AxiosSetup/service';
import router from '@/router';


@Component({
  components: {
  },
})
export default class Authorization extends Vue {
 public data: FormAuthorizationParam = new FormAuthorizationParam();
 
 public async Authorization()
 { 
   try {
     const result = await AccountService.Authorization(this.data);
      if (result)
        {
            router.push({ path: '/admin/addCheck' })
            localStorage.setItem('password', 'condominium');
        }
    }

    catch(e) {
      alert("Неверные данные для входа");
    }
    
 }
}

</script>

<style> 
.inputRegistration {
  width: 178px;
  border: 1px solid #0db3e3 !important;
  font-size: 20px;
  color: #0db3e3;
  background-color: white;
  padding: 5px 20px;
  cursor: pointer;
}


.inputRegistration:hover{
  background-color:#0db3e3 ;
  color: white;
   transition: 0.5s;
}
</style>