
export class AxiosBase {
    public axios: any;

    constructor() {
        this.axios = require("axios");
    }

}

export class HomeService {
    static urlBase = "http://localhost:13161/api/";
    static AxiosBase = new AxiosBase();

    //HomeController/GetAllCheck()
    static async GetAllCheck(): Promise<CheckDataModel[]> {
        const url = this.urlBase + "Home/GetAllCheck";
        const response = await this.AxiosBase.axios.get(url);

        return response.data as CheckDataModel[];
    }

    static async GetCheckById(id: number): Promise<CheckDataShortModel> {
        const url = this.urlBase + "Home/GetCheckById";
        const response = await this.AxiosBase.axios.get(url, {params: { id: id}});
        return response.data as CheckDataShortModel;
    }

    static async GetCheckByTagName(tagName : string): Promise<CheckDataModel[]> {
        const url = this.urlBase + "Home/GetCheckByTagName";
        const response = await this.AxiosBase.axios.get(url, {params: {tagName: tagName}});

        return response.data as CheckDataModel[];
    }
}

export class AccountService {
    static urlBase = "http://localhost:13161/api/";
    static AxiosBase = new AxiosBase();

    static async Authorization(data: FormAuthorizationParam): Promise<boolean> {

        const authorizationForm = new FormAuthorizationParam({
            Email : data.Email as string,
            Password : data.Password as string,
        });
        const url = this.urlBase + "Account/Authorization";
        const response = await this.AxiosBase.axios.post(url, authorizationForm);
        
        return response.data as boolean;
    }

}

export class AdminService {
    static urlBase = "http://localhost:13161/api/";
    static AxiosBase = new AxiosBase();

    static async AddCheck(data: FormAddCheckParams): Promise<boolean> {

        const addCheckForm = new FormAddCheckParams({
            Name : data.Name as string,
            IsCheckedVideoUrl : data.IsCheckedVideoUrl as boolean,
            CreateDate : data.CreateDate as Date,
            ImageUrl : data.ImageUrl as string,
            Text : data.Text as string,
            Tags : data.Tags as string[],
        });
    
        const url = this.urlBase + "Admin/AddCheck";
        const response = await this.AxiosBase.axios.post(url, addCheckForm);
        return response.data as boolean;
    }

    static async RemoveCheckById(id: number | undefined): Promise<boolean> {     
        const url = this.urlBase + "Admin/RemoveCheckById";
        
        const response = await this.AxiosBase.axios.get(url, {params: {checkId: id as number}});
        
        return response.data as boolean;
    }
}



export class CheckDataModel {
    /** Id */
    'Id'?: number;

    'CreateDate'?: string;

    'CheckAuthor'?: string;

    'IsCheckedVideoUrl'?: boolean;

    'Name'?: string;

    'CommentCount'?: number;

    'ImageUrl'?: string;

    'Text'?: string;

    'Tags'?: string[];

    constructor(data: undefined | any = {}) {
        this['Id'] = data['Id'];
        this['CreateDate'] = data['CreateDate'];
        this['Name'] = data['Name'];
        this['IsCheckedVideoUrl'] = data['IsCheckedVideoUrl'];
        this['CommentCount'] = data['CommentCount'];
        this['ImageUrl'] = data['ImageUrl'];
        this['Text'] = data['Text'];
        this['Tags'] = data['Tags'];    
        this['CheckAuthor'] = data['CheckAuthor'];    
    }

    public static validationModel = {};
}

export class CheckDataShortModel {
    /** Id */
    'Id'?: number;

    'CheckAuthor'?: string;

    'Name'?: string;

    'IsCheckedVideoUrl'?: boolean;

    'ImageUrl'?: string;

    'Text'?: string;

    'Tags'?: string[];


    constructor(data: undefined | any = {}) {
        this['Id'] = data['Id'];
        this['Name'] = data['Name'];
        this['ImageUrl'] = data['ImageUrl'];
        this['IsCheckedVideoUrl'] = data['IsCheckedVideoUrl'];
        this['Text'] = data['Text']; 
        this['CheckAuthor'] = data['CheckAuthor']; 
        this['Tags'] = data['Tags'];    
    }

    public static validationModel = {};
}

export class FormAuthorizationParam {
 
    'Email'?: string;

    'Password'?: string;


    constructor(data: undefined | any = {}) {
        this['Email'] = data['Email'];
        this['Password'] = data['Password'];    
    }

    public static validationModel = {};
}

export class FormAddCheckParams {

    'CreateDate'?: Date;

    'IsCheckedVideoUrl'?: boolean;

    'Name'?: string;

    'ImageUrl'?: string;

    'Text'?: string;

    'Tags'?: string[];

    constructor(data: undefined | any = {}) {
        this['CreateDate'] = data['CreateDate'];
        this['IsCheckedVideoUrl'] = data['IsCheckedVideoUrl'];
        this['Name'] = data['Name'];
        this['ImageUrl'] = data['ImageUrl'];
        this['Text'] = data['Text'];
        this['Tags'] = data['Tags'];       
    }

  public static validationModel = {};
}
