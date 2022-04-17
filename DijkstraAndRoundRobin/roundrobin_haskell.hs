-- 141180059 , Ümit SARIÖZ :: Programlama Dilleri Ödev 1 :: Haskell -> Round Robin 

import Control.Monad.State.Strict
import Data.List.NonEmpty (NonEmpty,fromList,toList)

initRR :: Monad m => NonEmpty a -> StateT [a] m b -> m b
initRR = flip evalStateT . cycle . toList

nextRR :: Monad m => StateT [a] m a
nextRR = do
  ~(a : as) <- get
  put  as
  pure a

main :: IO ()
main = initRR (fromList [1..10]) $ do
  a <- nextRR
  b <- nextRR
  c <- nextRR
  liftIO $ print (a,b,c)
