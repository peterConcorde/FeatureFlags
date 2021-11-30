export interface IAppConfig {
    env: { 
        name: string;
    };
    urls:{
        punkApiBaseAddress: string;
    }
    features: {
        featureA: boolean;
        featureB: boolean;
    };
}
