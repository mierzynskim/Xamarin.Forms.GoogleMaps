using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using Com.Google.Maps.Android.Clustering;
using Java.Lang;
using Xamarin.Forms.GoogleMaps.Android;
using XForms = Xamarin.Forms.Forms;

namespace Xamarin.Forms.GoogleMaps.Logics.Android
{
	internal class ClusterLogicHandler : Java.Lang.Object,
		ClusterManager.IOnClusterClickListener,
		ClusterManager.IOnClusterItemClickListener,
		ClusterManager.IOnClusterInfoWindowClickListener,
		ClusterManager.IOnClusterItemInfoWindowClickListener
	{
		private Map _map;
		private ClusterManager _clusterManager;
		private ClusterLogic _logic;

		public ClusterLogicHandler(Map map, ClusterManager manager, ClusterLogic logic)
		{
			this._map = map;
			this._clusterManager = manager;
			this._logic = logic;
		}

		public bool OnClusterClick(ICluster cluster)
		{
			//Toast.MakeText(XForms.Context, string.Format("{0} items in cluster", cluster.Items.Count), ToastLength.Short).Show();
			return false;
		}

		public bool OnClusterItemClick(Java.Lang.Object nativeItemObj)
		{
			var targetPin = _logic.LookupPin(nativeItemObj as ClusteredMarker);
           
			targetPin?.SendTap();

			if (targetPin != null)
			{
				if (!ReferenceEquals(targetPin, _map.SelectedPin))
					_map.SelectedPin = targetPin;
				_map.SendPinClicked(targetPin);
			}

			return false;
		}

		public void OnClusterInfoWindowClick(ICluster cluster)
		{

		}

		public void OnClusterItemInfoWindowClick(Java.Lang.Object nativeItemObj)
		{
            var targetPin = _logic.LookupPin(nativeItemObj as ClusteredMarker);
           
            targetPin?.SendTap();

            if (targetPin != null)
            {
                _map.SendInfoWindowClicked(targetPin);
            }
		}
    }
}