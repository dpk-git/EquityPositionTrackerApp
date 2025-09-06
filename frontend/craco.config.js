module.exports = {
    devServer: (devServerConfig) => {
      // remove deprecated props if present
      delete devServerConfig.onBeforeSetupMiddleware;
      delete devServerConfig.onAfterSetupMiddleware;
  
      // use setupMiddlewares instead
      devServerConfig.setupMiddlewares = (middlewares, devServer) => {
        if (!devServer) {
          throw new Error('webpack-dev-server is not defined');
        }
  
        devServer.app.get('/api', (req, res) => {
          res.json({ message: 'Hello from mock API!' });
        });
  
        return middlewares;
      };
  
      return devServerConfig;
    },
  };
  